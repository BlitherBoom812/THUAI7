﻿using Playback;
using Protobuf;
using System.Collections.Concurrent;
using Timothy.FrameRateTask;

namespace Server
{
    class PlaybackServer(ArgumentOptions options) : ServerBase
    {
        protected readonly ArgumentOptions options = options;
        private int[] teamScore = new int[0];
        private ConcurrentDictionary<long, (SemaphoreSlim, SemaphoreSlim)> semaDict = new();
        // private object semaDictLock = new();
        private MessageToClient? currentGameInfo = new();
        private MessageOfObj currentMapMsg = new();
        private uint spectatorMinPlayerID = 2023;
        // private List<uint> spectatorList = new List<uint>();
        public int TeamCount => options.TeamCount;
        private object spectatorJoinLock = new();
        protected object spectatorLock = new();
        protected bool isSpectatorJoin = false;
        protected bool IsSpectatorJoin
        {
            get
            {
                lock (spectatorLock)
                    return isSpectatorJoin;
            }

            set
            {
                lock (spectatorLock)
                    isSpectatorJoin = value;
            }
        }
        private bool IsGaming { get; set; } = true;
        private int[] finalScore = new int[0];
        public int[] FinalScore
        {
            get
            {
                return finalScore;
            }
        }
        public override int[] GetMoney() => new int[0];
        public override int[] GetScore() => FinalScore;

        //public override async Task AddPlayer(PlayerMsg request, IServerStreamWriter<MessageToClient> responseStream, ServerCallContext context)
        //{
        //    Console.WriteLine($"AddPlayer: {request.PlayerId}");
        //    if (request.PlayerId >= spectatorMinPlayerID && options.NotAllowSpectator == false)
        //    {
        //        // 观战模式
        //        lock (spectatorJoinLock) // 具体原因见另一个上锁的地方
        //        {
        //            if (semaDict.TryAdd(request.PlayerId, (new SemaphoreSlim(0, 1), new SemaphoreSlim(0, 1))))
        //            {
        //                Console.WriteLine("A new spectator comes to watch this game.");
        //                IsSpectatorJoin = true;
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Duplicated Spectator ID {request.PlayerId}");
        //                return;
        //            }
        //        }
        //        do
        //        {
        //            semaDict[request.PlayerId].Item1.Wait();
        //            try
        //            {
        //                if (currentGameInfo != null)
        //                {
        //                    await responseStream.WriteAsync(currentGameInfo);
        //                    Console.WriteLine("Send!");
        //                }
        //            }
        //            catch (InvalidOperationException)
        //            {
        //                if (semaDict.TryRemove(request.PlayerId, out var semas))
        //                {
        //                    try
        //                    {
        //                        semas.Item1.Release();
        //                        semas.Item2.Release();
        //                    }
        //                    catch { }
        //                    Console.WriteLine($"The spectator {request.PlayerId} exited");
        //                    return;
        //                }
        //            }
        //            catch (Exception)
        //            {
        //                // Console.WriteLine(ex);
        //            }
        //            finally
        //            {
        //                try
        //                {
        //                    semaDict[request.PlayerId].Item2.Release();
        //                }
        //                catch { }
        //            }
        //        } while (IsGaming);
        //        return;
        //    }
        //}

        public void ReportGame(MessageToClient? msg)
        {
            currentGameInfo = msg;
            if (currentGameInfo != null && currentGameInfo.GameState == GameState.GameStart)
            {
                currentMapMsg = currentGameInfo.ObjMessage[0];
            }

            if (currentGameInfo != null && IsSpectatorJoin)
            {
                currentGameInfo.ObjMessage.Add(currentMapMsg);
                IsSpectatorJoin = false;
            }

            foreach (var kvp in semaDict)
            {
                kvp.Value.Item1.Release();
            }

            foreach (var kvp in semaDict)
            {
                kvp.Value.Item2.Wait();
            }
        }

        public override void WaitForEnd()
        {
            try
            {
                if (options.ResultOnly)
                {
                    using (MessageReader mr = new(options.FileName))
                    {
                        Console.WriteLine("Parsing playback file...");
                        teamScore = new int[mr.teamCount];
                        finalScore = new int[mr.teamCount];
                        int infoNo = 0;
                        object cursorLock = new();
                        var initialTop = Console.CursorTop;
                        var initialLeft = Console.CursorLeft;
                        while (true)
                        {
                            MessageToClient? msg = null;
                            for (int i = 0; i < mr.teamCount; ++i)
                            {
                                for (int j = 0; j < mr.playerCount; ++j)
                                {
                                    msg = mr.ReadOne();
                                    if (msg == null)
                                    {
                                        Console.WriteLine("The game doesn't come to an end because of timing up!");
                                        IsGaming = false;
                                        goto endParse;
                                    }

                                    lock (cursorLock)
                                    {
                                        var curTop = Console.CursorTop;
                                        var curLeft = Console.CursorLeft;
                                        Console.SetCursorPosition(initialLeft, initialTop);
                                        Console.WriteLine($"Parsing messages... Current message number: {infoNo}");
                                        Console.SetCursorPosition(curLeft, curTop);
                                    }

                                    if (msg != null)
                                    {
                                        //teamScore[i] = msg.TeamScore;
                                    }
                                }
                            }

                            ++infoNo;

                            if (msg == null)
                            {
                                Console.WriteLine("No game information in this file!");
                                goto endParse;
                            }
                            if (msg.GameState == GameState.GameEnd)
                            {
                                Console.WriteLine("Game over normally!");
                                finalScore[0] = msg.AllMessage.RedteamScore;
                                finalScore[1] = msg.AllMessage.BlueteamScore;
                                goto endParse;
                            }
                        }

                    endParse:

                        Console.WriteLine($"Successfully parsed {infoNo} informations!");
                    }
                }
                else
                {
                    long timeInterval = GameServer.SendMessageToClientIntervalInMilliseconds;
                    if (options.PlaybackSpeed != 1.0)
                    {
                        options.PlaybackSpeed = Math.Max(0.25, Math.Min(4.0, options.PlaybackSpeed));
                        timeInterval = (int)Math.Round(timeInterval / options.PlaybackSpeed);
                    }
                    using (MessageReader mr = new(options.FileName))
                    {
                        teamScore = new int[mr.teamCount];
                        finalScore = new int[mr.teamCount];
                        int infoNo = 0;
                        object cursorLock = new();
                        var msgCurTop = Console.CursorTop;
                        var msgCurLeft = Console.CursorLeft;
                        var frt = new FrameRateTaskExecutor<int>
                        (
                            loopCondition: () => true,
                            loopToDo: () =>
                            {
                                MessageToClient? msg = null;

                                msg = mr.ReadOne();
                                if (msg == null)
                                {
                                    Console.WriteLine("The game doesn't come to an end because of timing up!");
                                    IsGaming = false;
                                    ReportGame(msg);
                                    return false;
                                }
                                ReportGame(msg);
                                lock (cursorLock)
                                {
                                    var curTop = Console.CursorTop;
                                    var curLeft = Console.CursorLeft;
                                    Console.SetCursorPosition(msgCurLeft, msgCurTop);
                                    Console.WriteLine($"Sending messages... Current message number: {infoNo}.");
                                    Console.SetCursorPosition(curLeft, curTop);
                                }
                                if (msg != null)
                                {
                                    foreach (var item in msg.ObjMessage)
                                    {
                                        if (item.TeamMessage != null)
                                            teamScore[item.TeamMessage.TeamId] = item.TeamMessage.Score;

                                    }
                                }

                                ++infoNo;
                                if (msg == null)
                                {
                                    Console.WriteLine("No game information in this file!");
                                    IsGaming = false;
                                    ReportGame(msg);
                                    return false;
                                }
                                if (msg.GameState == GameState.GameEnd)
                                {
                                    Console.WriteLine("Game over normally!");
                                    IsGaming = false;
                                    finalScore[0] = msg.AllMessage.BlueteamScore;
                                    finalScore[1] = msg.AllMessage.RedteamScore;
                                    ReportGame(msg);
                                    return false;
                                }
                                return true;
                            },
                            timeInterval: timeInterval,
                            finallyReturn: () => 0
                        )
                        { AllowTimeExceed = true, MaxTolerantTimeExceedCount = 5 };

                        Console.WriteLine("The server is well prepared! Please MAKE SURE that you have opened all the clients to watch the game!");
                        Console.WriteLine("If ALL clients have opened, press any key to start.");
                        Console.ReadKey();

                        new Thread
                            (
                                () =>
                                {
                                    var rateCurTop = Console.CursorTop;
                                    var rateCurLeft = Console.CursorLeft;
                                    lock (cursorLock)
                                    {
                                        rateCurTop = Console.CursorTop;
                                        rateCurLeft = Console.CursorLeft;
                                        Console.WriteLine($"Send message to clients frame rate: {frt.FrameRate}");
                                    }
                                    while (!frt.Finished)
                                    {
                                        lock (cursorLock)
                                        {
                                            var curTop = Console.CursorTop;
                                            var curLeft = Console.CursorLeft;
                                            Console.SetCursorPosition(rateCurLeft, rateCurTop);
                                            Console.WriteLine($"Send message to clients frame rate: {frt.FrameRate}");
                                            Console.SetCursorPosition(curLeft, curTop);
                                        }
                                        Thread.Sleep(1000);
                                    }
                                }
                            )
                        { IsBackground = true }.Start();

                        lock (cursorLock)
                        {
                            msgCurLeft = Console.CursorLeft;
                            msgCurTop = Console.CursorTop;
                            Console.WriteLine("Sending messages...");
                        }
                        frt.Start();
                    }
                }
            }
            finally
            {
                teamScore ??= new int[0];
            }
        }
    }
}
