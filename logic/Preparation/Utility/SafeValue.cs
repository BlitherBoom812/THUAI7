﻿using System;
using System.Threading;

namespace Preparation.Utility
{
    //理论上结构体最好不可变，这里采用了可变结构。
    //其对应属性不应当有set访问器，避免不安全的=赋值
    public class AtomicInt
    {
        private int v;
        public AtomicInt(int x)
        {
            v = x;
        }
        public override string ToString() => Interlocked.CompareExchange(ref v, -1, -1).ToString();
        public int Get() => Interlocked.CompareExchange(ref v, -1, -1);
        public static implicit operator int(AtomicInt aint) => Interlocked.CompareExchange(ref aint.v, -1, -1);
        /// <returns>返回操作前的值</returns>
        public int SetReturnOri(int value) => Interlocked.Exchange(ref v, value);
        public int Add(int x) => Interlocked.Add(ref v, x);
        public int Sub(int x) => Interlocked.Add(ref v, -x);
        public int Inc() => Interlocked.Increment(ref v);
        public int Dec() => Interlocked.Decrement(ref v);
        /// <returns>返回操作前的值</returns>
        public int CompareExReturnOri(int newV, int compareTo) => Interlocked.CompareExchange(ref v, newV, compareTo);
    }

    public class AtomicLong
    {
        private long v;
        public AtomicLong(long x)
        {
            v = x;
        }
        public override string ToString() => Interlocked.Read(ref v).ToString();
        public long Get() => Interlocked.Read(ref v);
        public static implicit operator long(AtomicLong aint) => Interlocked.Read(ref aint.v);
        /// <returns>返回操作前的值</returns>
        public long SetReturnOri(long value) => Interlocked.Exchange(ref v, value);
        public long Add(long x) => Interlocked.Add(ref v, x);
        public long Sub(long x) => Interlocked.Add(ref v, -x);
        public long Inc() => Interlocked.Increment(ref v);
        public long Dec() => Interlocked.Decrement(ref v);
        /// <returns>返回操作前的值</returns>
        public long CompareExReturnOri(long newV, long compareTo) => Interlocked.CompareExchange(ref v, newV, compareTo);
    }

    public class AtomicBool
    {
        private int v;//v==0为false,v==1为true
        public AtomicBool(bool x)
        {
            v = x ? 1 : 0;
        }
        public override string ToString() => (Interlocked.CompareExchange(ref v, -2, -2) == 0) ? "false" : "true";
        public bool Get() => (Interlocked.CompareExchange(ref v, -1, -1) != 0);
        public static implicit operator bool(AtomicBool abool) => (Interlocked.CompareExchange(ref abool.v, -1, -1) != 0);
        /// <returns>返回操作前的值</returns>
        public bool SetReturnOri(bool value) => (Interlocked.Exchange(ref v, value ? 1 : 0) != 0);
        /// <returns>赋值前的值是否与将赋予的值不相同</returns>
        public bool TrySet(bool value)
        {
            return (Interlocked.CompareExchange(ref v, value ? 1 : 0, value ? 0 : 1) ^ (value ? 1 : 0)) != 0;
        }
        public bool And(bool x) => Interlocked.And(ref v, x ? 1 : 0) != 0;
        public bool Or(bool x) => Interlocked.Or(ref v, x ? 1 : 0) != 0;
    }

    /// <summary>
    /// 根据时间推算Start后完成多少进度的进度条（long）。
    /// 只允许Start时修改needTime（请确保大于0）；
    /// 支持TrySet0使未完成的进度条终止清零；支持Set0使进度条强制终止清零；
    /// 通过原子操作实现。
    /// </summary>
    public class LongProgressByTime
    {
        private long endT = long.MaxValue;
        private long needT;

        public LongProgressByTime(long needTime)
        {
            if (needTime <= 0) Debugger.Output("Bug:LongProgressByTime.needTime (" + needTime.ToString() + ") is less than 0.");
            this.needT = needTime;
        }
        public LongProgressByTime()
        {
            this.needT = 0;
        }
        public long GetEndTime() => Interlocked.CompareExchange(ref endT, -2, -2);
        public long GetNeedTime() => Interlocked.CompareExchange(ref needT, -2, -2);
        public override string ToString() => "EndTime:" + Interlocked.CompareExchange(ref endT, -2, -2).ToString() + " ms, NeedTime:" + Interlocked.CompareExchange(ref needT, -2, -2).ToString() + " ms";
        public bool IsFinished()
        {
            return Interlocked.CompareExchange(ref endT, -2, -2) <= Environment.TickCount64;
        }
        public bool IsOpened() => Interlocked.Read(ref endT) != long.MaxValue;
        /// <summary>
        /// GetProgress<0则表明未开始
        /// </summary>
        public long GetProgress()
        {
            long cutime = Interlocked.CompareExchange(ref endT, -2, -2) - Environment.TickCount64;
            if (cutime <= 0) return Interlocked.CompareExchange(ref needT, -2, -2);
            return Interlocked.CompareExchange(ref needT, -2, -2) - cutime;
        }
        public long GetNonNegativeProgress()
        {
            long cutime = Interlocked.CompareExchange(ref endT, -2, -2) - Environment.TickCount64;
            if (cutime <= 0) return Interlocked.CompareExchange(ref needT, -2, -2);
            long progress = Interlocked.CompareExchange(ref needT, -2, -2) - cutime;
            return progress < 0 ? 0 : progress;
        }
        /// <summary>
        /// GetProgress<0则表明未开始
        /// </summary>
        public long GetProgress(long time)
        {
            long cutime = Interlocked.CompareExchange(ref endT, -2, -2) - time;
            if (cutime <= 0) return Interlocked.CompareExchange(ref needT, -2, -2);
            return Interlocked.CompareExchange(ref needT, -2, -2) - cutime;
        }
        public long GetNonNegativeProgress(long time)
        {
            long cutime = Interlocked.Read(ref endT) - time;
            if (cutime <= 0) return Interlocked.CompareExchange(ref needT, -2, -2);
            long progress = Interlocked.CompareExchange(ref needT, -2, -2) - cutime;
            return progress < 0 ? 0 : progress;
        }
        /// <summary>
        /// <0则表明未开始
        /// </summary>
        public static implicit operator long(LongProgressByTime pLong) => pLong.GetProgress();

        /// <summary>
        /// GetProgressDouble<0则表明未开始
        /// </summary>
        public double GetProgressDouble()
        {
            long cutime = Interlocked.CompareExchange(ref endT, -2, -2) - Environment.TickCount64;
            if (cutime <= 0) return 1;
            long needTime = Interlocked.CompareExchange(ref needT, -2, -2);
            if (needTime == 0) return 0;
            return 1.0 - ((double)cutime / needTime);
        }
        public double GetNonNegativeProgressDouble(long time)
        {
            long cutime = Interlocked.Read(ref endT) - time;
            if (cutime <= 0) return 1;
            long needTime = Interlocked.CompareExchange(ref needT, -2, -2);
            if (needTime <= cutime) return 0;
            return 1.0 - ((double)cutime / needTime);
        }

        public bool Start(long needTime)
        {
            if (needTime <= 0)
            {
                Debugger.Output("Warning:Start LongProgressByTime with the needTime (" + needTime.ToString() + ") which is less than 0.");
                return false;
            }
            //规定只有Start可以修改needT，且需要先访问endTime，从而避免锁（某种程度上endTime可以认为是needTime的锁）
            if (Interlocked.CompareExchange(ref endT, Environment.TickCount64 + needTime, long.MaxValue) != long.MaxValue) return false;
            if (needTime <= 2) Debugger.Output("Warning:the field of LongProgressByTime is " + needTime.ToString() + ",which is too small.");
            Interlocked.Exchange(ref needT, needTime);
            return true;
        }
        public bool Start()
        {
            long needTime = Interlocked.CompareExchange(ref needT, -2, -2);
            if (Interlocked.CompareExchange(ref endT, Environment.TickCount64 + needTime, long.MaxValue) != long.MaxValue) return false;
            return true;
        }
        /// <summary>
        /// 使进度条强制终止清零
        /// </summary>
        public void Set0() => Interlocked.Exchange(ref endT, long.MaxValue);
        /// <summary>
        /// 使未完成的进度条终止清零
        /// </summary>
        public bool TrySet0()
        {
            if (Environment.TickCount64 < Interlocked.CompareExchange(ref endT, -2, -2))
            {
                Interlocked.Exchange(ref endT, long.MaxValue);
                return true;
            }
            return false;
        }
        //增加其他新的写操作可能导致不安全
    }

    /*
    /// <summary>
    /// 记录（不是根据时间）完成多少进度的进度条（long）。
    /// </summary>
    public struct IntProgressByAdding
    {
        private int completedProgress = -1;
        private int requiredProgress;
        public IntProgressByAdding(int completedProgress, int requiredProgress)
        {
            this.completedProgress = completedProgress;
            this.requiredProgress = requiredProgress;
        }
        public IntProgressByAdding(int requiredProgress)
        {
            this.requiredProgress = requiredProgress;
        }
        public IntProgressByAdding() 
        {
            this.requiredProgress=int.MaxValue;
        }
    }
    */

    /// <summary>
    /// 一个保证在[0,maxValue]的可变int，支持可变的maxValue(请确保大于0)
    /// </summary>
    public class IntWithVariableRange
    {
        private int v;
        private int maxV;
        private readonly object vLock = new();
        public IntWithVariableRange(int value, int maxValue)
        {
            if (maxValue < 0)
            {
                Debugger.Output("Warning:Try to set IntWithVariableRange.maxValue to " + maxValue.ToString() + ".");
                maxValue = 0;
            }
            v = value < maxValue ? value : maxValue;
            this.maxV = maxValue;
        }
        /// <summary>
        /// 默认使Value=maxValue
        /// </summary>
        public IntWithVariableRange(int maxValue)
        {
            if (maxValue < 0)
            {
                Debugger.Output("Warning:Try to set IntWithVariableRange.maxValue to " + maxValue.ToString() + ".");
                maxValue = 0;
            }
            v = this.maxV = maxValue;
        }
        public IntWithVariableRange()
        {
            v = this.maxV = int.MaxValue;
        }

        public override string ToString()
        {
            lock (vLock)
            {
                return "value:" + v.ToString() + " ,maxValue:" + maxV.ToString();
            }
        }
        public int GetValue() { lock (vLock) return v; }
        public static implicit operator int(IntWithVariableRange aint) => aint.GetValue();
        public int GetMaxV() { lock (vLock) return maxV; }

        /// <summary>
        /// 若maxValue<=0则maxValue设为0并返回False
        /// </summary>
        public bool SetMaxV(int maxValue)
        {
            if (maxValue < 0) maxValue = 0;
            lock (vLock)
            {
                maxV = maxValue;
                if (v > maxValue) v = maxValue;
            }
            return maxValue > 0;
        }
        /// <summary>
        /// 应当保证该maxValue>=0
        /// </summary>
        public void SetPositiveMaxV(int maxValue)
        {
            lock (vLock)
            {
                maxV = maxValue;
                if (v > maxValue) v = maxValue;
            }
        }
        /// <summary>
        /// 应当保证该value>=0
        /// </summary>
        public int SetPositiveV(int value)
        {
            lock (vLock)
            {
                return v = (value > maxV) ? maxV : value;
            }
        }
        public int SetV(int value)
        {
            if (value < 0) value = 0;
            lock (vLock)
            {
                return v = (value > maxV) ? maxV : value;
            }
        }
        /// <summary>
        /// 返回实际改变量
        /// </summary>
        public int AddV(int addV)
        {
            lock (vLock)
            {
                int previousV = v;
                v += addV;
                if (v < 0) v = 0;
                if (v > maxV) v = maxV;
                return v - previousV;
            }
        }
        /// <summary>
        /// 应当保证该增加值大于0,返回实际改变量
        /// </summary>
        public int AddPositiveV(int addPositiveV)
        {
            lock (vLock)
            {
                addPositiveV = Math.Min(addPositiveV, maxV - v);
                v += addPositiveV;
            }
            return addPositiveV;
        }
        /// <summary>
        /// 应当保证该减少值大于0,返回实际改变量
        /// </summary>
        public int SubPositiveV(int subPositiveV)
        {
            lock (vLock)
            {
                subPositiveV = Math.Min(subPositiveV, v);
                v -= subPositiveV;
            }
            return subPositiveV;
        }

        /// <summary>
        /// 试图加到满，如果无法加到maxValue则不加并返回-1
        /// </summary>
        public int TryAddAll(int addV)
        {
            lock (vLock)
            {
                if (maxV - v <= addV)
                {
                    addV = maxV - v;
                    v = maxV;
                    return addV;
                }
                return 0;
            }
        }
    }

    /// <summary>
    /// 一个保证在[0,maxValue]的可变long，支持可变的maxValue(请确保大于0)
    /// </summary>
    public class LongWithVariableRange
    {
        private long v;
        private long maxV;
        private readonly object vLock = new();
        public LongWithVariableRange(long value, long maxValue)
        {
            if (maxValue < 0)
            {
                Debugger.Output("Warning:Try to set SafaValues.LongWithVariableRange.maxValue to " + maxValue.ToString() + ".");
                maxValue = 0;
            }
            v = value < maxValue ? value : maxValue;
            this.maxV = maxValue;
        }
        /// <summary>
        /// 默认使Value=maxValue
        /// </summary>
        public LongWithVariableRange(long maxValue)
        {
            if (maxValue < 0)
            {
                Debugger.Output("Warning:Try to set SafaValues.LongWithVariableRange.maxValue to " + maxValue.ToString() + ".");
                maxValue = 0;
            }
            v = this.maxV = maxValue;
        }
        public LongWithVariableRange()
        {
            v = this.maxV = long.MaxValue;
        }

        public override string ToString()
        {
            lock (vLock)
            {
                return "value:" + v.ToString() + " ,maxValue:" + maxV.ToString();
            }
        }
        public long GetValue() { lock (vLock) return v; }
        public static implicit operator long(LongWithVariableRange aint) => aint.GetValue();
        public long GetMaxV() { lock (vLock) return maxV; }

        /// <summary>
        /// 若maxValue<=0则maxValue设为0并返回False
        /// </summary>
        public bool SetMaxV(long maxValue)
        {
            if (maxValue < 0) maxValue = 0;
            lock (vLock)
            {
                maxV = maxValue;
                if (v > maxValue) v = maxValue;
            }
            return maxValue > 0;
        }
        /// <summary>
        /// 应当保证该maxValue>=0
        /// </summary>
        public void SetPositiveMaxV(long maxValue)
        {
            lock (vLock)
            {
                maxV = maxValue;
                if (v > maxValue) v = maxValue;
            }
        }
        /// <summary>
        /// 应当保证该value>=0
        /// </summary>
        public long SetPositiveV(long value)
        {
            lock (vLock)
            {
                return v = (value > maxV) ? maxV : value;
            }
        }
        public long SetV(long value)
        {
            if (value < 0) value = 0;
            lock (vLock)
            {
                return v = (value > maxV) ? maxV : value;
            }
        }
        /// <summary>
        /// 返回实际改变量
        /// </summary>
        public long AddV(long addV)
        {
            lock (vLock)
            {
                long previousV = v;
                v += addV;
                if (v < 0) v = 0;
                if (v > maxV) v = maxV;
                return v - previousV;
            }
        }
        /// <summary>
        /// 应当保证该增加值大于0,返回实际改变量
        /// </summary>
        public long AddPositiveV(long addPositiveV)
        {
            lock (vLock)
            {
                addPositiveV = Math.Min(addPositiveV, maxV - v);
                v += addPositiveV;
            }
            return addPositiveV;
        }
        /// <summary>
        /// 应当保证该减少值大于0,返回实际改变量
        /// </summary>
        public long SubPositiveV(long subPositiveV)
        {
            lock (vLock)
            {
                subPositiveV = Math.Min(subPositiveV, v);
                v -= subPositiveV;
            }
            return subPositiveV;
        }

        /// <summary>
        /// 试图加到满，如果无法加到maxValue则不加并返回-1
        /// </summary>
        public long TryAddAll(long addV)
        {
            lock (vLock)
            {
                if (maxV - v <= addV)
                {
                    addV = maxV - v;
                    v = maxV;
                    return addV;
                }
                return -1;
            }
        }
    }

    /// <summary>
    /// 一个保证在[0,maxNum],每CDms自动+1的int，支持可变的CD、maxNum(请确保大于0)
    /// </summary>
    public class IntNumUpdateByCD
    {
        private int num;
        private int maxNum;
        private int cd;
        private long updateTime = 0;
        private readonly object numLock = new();
        public IntNumUpdateByCD(int num, int maxNum, int cd)
        {
            if (num < 0) Debugger.Output("Bug:IntNumUpdateByCD.num (" + num.ToString() + ") is less than 0.");
            if (maxNum < 0) Debugger.Output("Bug:IntNumUpdateByCD.maxNum (" + maxNum.ToString() + ") is less than 0.");
            if (cd <= 0) Debugger.Output("Bug:IntNumUpdateByCD.cd (" + cd.ToString() + ") is less than 0.");
            this.num = (num < maxNum) ? num : maxNum;
            this.maxNum = maxNum;
            this.cd = cd;
            this.updateTime = Environment.TickCount64;
        }
        /// <summary>
        /// 默认使num=maxNum
        /// </summary>
        public IntNumUpdateByCD(int maxNum, int cd)
        {
            if (maxNum < 0) Debugger.Output("Bug:IntNumUpdateByCD.maxNum (" + maxNum.ToString() + ") is less than 0.");
            if (cd <= 0) Debugger.Output("Bug:IntNumUpdateByCD.cd (" + cd.ToString() + ") is less than 0.");
            this.num = this.maxNum = maxNum;
            this.cd = cd;
        }
        public IntNumUpdateByCD()
        {
            this.num = this.maxNum = 0;
            this.cd = int.MaxValue;
        }

        public int GetMaxNum() { lock (numLock) return maxNum; }
        public int GetCD() { lock (numLock) return cd; }
        public int GetNum(long time)
        {
            lock (numLock)
            {
                if (num < maxNum && time - updateTime >= cd)
                {
                    int add = (int)Math.Min(maxNum - num, (time - updateTime) / cd);
                    updateTime += add * cd;
                    return (num += add);
                }
                return num;
            }
        }
        public static implicit operator int(IntNumUpdateByCD aint) => aint.GetNum(Environment.TickCount64);

        /// <summary>
        /// 应当保证该subV>=0
        /// </summary>
        public int TrySub(int subV)
        {
            if (subV < 0) Debugger.Output("Bug:IntNumUpdateByCD Try to sub " + subV.ToString() + ", which is less than 0.");
            long time = Environment.TickCount64;
            lock (numLock)
            {
                if (num < maxNum && time - updateTime >= cd)
                {
                    int add = (int)Math.Min(maxNum - num, (time - updateTime) / cd);
                    updateTime += add * cd;
                    num += add;
                }
                if (num == maxNum) updateTime = time;
                num -= subV = Math.Min(subV, num);
            }
            return subV;
        }
        /// <summary>
        /// 应当保证该addV>=0
        /// </summary>
        public void TryAdd(int addV)
        {
            if (addV < 0) Debugger.Output("Bug:IntNumUpdateByCD Try to add " + addV.ToString() + ", which is less than 0.");
            lock (numLock)
            {
                num += Math.Min(addV, maxNum - num);
            }
        }
        /// <summary>
        /// 若maxNum<=0则maxNum及Num设为0并返回False
        /// </summary>
        public bool SetMaxNumAndNum(int maxNum)
        {
            if (maxNum < 0) maxNum = 0;
            lock (numLock)
            {
                this.num = this.maxNum = maxNum;
            }
            return maxNum > 0;
        }
        /// <summary>
        /// 应当保证该maxnum>=0
        /// </summary>
        public void SetPositiveMaxNumAndNum(int maxNum)
        {
            lock (numLock)
            {
                this.num = this.maxNum = maxNum;
            }
        }
        /// <summary>
        /// 应当保证该maxnum>=0
        /// </summary>
        public void SetPositiveMaxNum(int maxNum)
        {
            lock (numLock)
            {
                if ((this.maxNum = maxNum) < num)
                    num = maxNum;
            }
        }
        /// <summary>
        /// 若maxNum<=0则maxNum及Num设为0并返回False
        /// </summary>
        public bool SetMaxNum(int maxNum)
        {
            if (maxNum < 0) maxNum = 0;
            lock (numLock)
            {
                if ((this.maxNum = maxNum) < num)
                    num = maxNum;
            }
            return maxNum > 0;
        }
        /// <summary>
        /// 若num<0则num设为0并返回False
        /// </summary>
        public bool SetNum(int num)
        {
            lock (numLock)
            {
                if (num < 0)
                {
                    this.num = 0;
                    updateTime = Environment.TickCount64;
                    return false;
                }
                if (num < maxNum)
                {
                    if (this.num == maxNum) updateTime = Environment.TickCount64;
                    this.num = num;
                }
                else this.num = maxNum;
                return true;
            }
        }
        /// <summary>
        /// 应当保证该num>=0
        /// </summary>
        public void SetPositiveNum(int num)
        {
            lock (numLock)
            {
                if (num < maxNum)
                {
                    if (this.num == maxNum) updateTime = Environment.TickCount64;
                    this.num = num;
                }
                else this.num = maxNum;
            }
        }
        public void SetCD(int cd)
        {
            lock (numLock)
            {
                if (cd <= 0) Debugger.Output("Bug:SetReturnOri IntNumUpdateByCD.cd to " + cd.ToString() + ".");
                this.cd = cd;
            }
        }
    }

    /// <summary>
    /// 一个每CDms自动更新冷却的bool，支持可变的无锁CD，不支持查看当前进度，初始为True
    /// </summary>
    public class BoolCoolingDownByCD
    {
        private long cd;
        private long nextUpdateTime = 0;
        public BoolCoolingDownByCD(int cd)
        {
            if (cd <= 1) Debugger.Output("Bug:IntNumUpdateByCD.cd (" + cd.ToString() + ") is less than 1.");
            this.cd = cd;
        }
        public BoolCoolingDownByCD(long cd)
        {
            if (cd <= 1) Debugger.Output("Bug:IntNumUpdateByCD.cd (" + cd.ToString() + ") is less than 1.");
            this.cd = cd;
        }
        public BoolCoolingDownByCD(long cd, long startTime)
        {
            if (cd <= 1) Debugger.Output("Bug:IntNumUpdateByCD.cd (" + cd.ToString() + ") is less than 1.");
            this.cd = cd;
            this.nextUpdateTime = startTime;
        }

        public long GetCD() => Interlocked.Read(ref cd);

        public bool TryUse()
        {
            long needTime = Interlocked.Exchange(ref nextUpdateTime, long.MaxValue);
            if (needTime <= Environment.TickCount64)
            {
                Interlocked.Exchange(ref nextUpdateTime, Environment.TickCount64 + Interlocked.Read(ref cd));
                return true;
            }
            Interlocked.Exchange(ref nextUpdateTime, needTime);
            return false;
        }
        public void SetCD(int cd)
        {
            if (cd <= 1) Debugger.Output("Bug:SetReturnOri IntNumUpdateByCD.cd to " + cd.ToString() + ".");
            Interlocked.Exchange(ref this.cd, cd);
        }
    }

    /// <summary>
    /// 一个每CDms自动更新的进度条，支持可变的CD，初始为满
    /// </summary>
    public class LongProgressCoolingDownByCD
    {
        private int isusing = 0;
        private long cd;
        private long nextUpdateTime = 0;
        public LongProgressCoolingDownByCD(int cd)
        {
            if (cd <= 1) Debugger.Output("Bug:IntNumUpdateByCD.cd (" + cd.ToString() + ") is less than 1.");
            this.cd = cd;
        }
        public LongProgressCoolingDownByCD(long cd)
        {
            if (cd <= 1) Debugger.Output("Bug:IntNumUpdateByCD.cd (" + cd.ToString() + ") is less than 1.");
            this.cd = cd;
        }
        public LongProgressCoolingDownByCD(long cd, long startTime)
        {
            if (cd <= 1) Debugger.Output("Bug:IntNumUpdateByCD.cd (" + cd.ToString() + ") is less than 1.");
            this.cd = cd;
            this.nextUpdateTime = startTime;
        }

        public long GetRemainingTime()
        {
            long v = Interlocked.Read(ref nextUpdateTime) - Environment.TickCount64;
            return v < 0 ? 0 : v;
        }
        public long GetCD() => Interlocked.Read(ref cd);

        public bool TryUse()
        {
            if (Interlocked.Exchange(ref isusing, 1) == 1) return false;
            long needTime = Interlocked.Read(ref nextUpdateTime);
            if (needTime <= Environment.TickCount64)
            {
                Interlocked.Exchange(ref nextUpdateTime, Environment.TickCount64 + Interlocked.Read(ref cd));
                Interlocked.Exchange(ref isusing, 0);
                return true;
            }
            Interlocked.Exchange(ref isusing, 0);
            return false;
        }
        public void SetCD(int cd)
        {
            if (cd <= 1) Debugger.Output("Bug:SetReturnOri IntNumUpdateByCD.cd to " + cd.ToString() + ".");
            Interlocked.Exchange(ref this.cd, cd);
        }
    }
}
