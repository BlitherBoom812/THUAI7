// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: MessageType.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Protobuf {

  /// <summary>Holder for reflection information generated from MessageType.proto</summary>
  public static partial class MessageTypeReflection {

    #region Descriptor
    /// <summary>File descriptor for MessageType.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MessageTypeReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFNZXNzYWdlVHlwZS5wcm90bxIIcHJvdG9idWYqUAoJR2FtZVN0YXRlEhMK",
            "D05VTExfR0FNRV9TVEFURRAAEg4KCkdBTUVfU1RBUlQQARIQCgxHQU1FX1JV",
            "Tk5JTkcQAhIMCghHQU1FX0VORBADKocBCglQbGFjZVR5cGUSEwoPTlVMTF9Q",
            "TEFDRV9UWVBFEAASCAoESE9NRRABEgkKBVNQQUNFEAISCAoEUlVJThADEgoK",
            "BlNIQURPVxAEEgwKCEFTVEVST0lEEAUSDAoIUkVTT1VSQ0UQBhIQCgxDT05T",
            "VFJVQ1RJT04QBxIMCghXT1JNSE9MRRAIKjgKCVNoYXBlVHlwZRITCg9OVUxM",
            "X1NIQVBFX1RZUEUQABIKCgZDSVJDTEUQARIKCgZTUVVBUkUQAio2CgpQbGF5",
            "ZXJUeXBlEhQKEE5VTExfUExBWUVSX1RZUEUQABIICgRTSElQEAESCAoEVEVB",
            "TRACKlMKCFNoaXBUeXBlEhIKDk5VTExfU0hJUF9UWVBFEAASEQoNQ0lWSUxJ",
            "QU5fU0hJUBABEhEKDU1JTElUQVJZX1NISVAQAhINCglGTEFHX1NISVAQAyqc",
            "AQoJU2hpcFN0YXRlEg8KC05VTExfU1RBVFVTEAASCAoESURMRRABEg0KCVBS",
            "T0RVQ0lORxACEhAKDENPTlNUUlVDVElORxADEg4KClJFQ09WRVJJTkcQBBIN",
            "CglSRUNZQ0xJTkcQBRINCglBVFRBQ0tJTkcQBhIMCghTV0lOR0lORxAHEgsK",
            "B1NUVU5ORUQQCBIKCgZNT1ZJTkcQCSppCgpXZWFwb25UeXBlEhQKEE5VTExf",
            "V0VBUE9OX1RZUEUQABIMCghMQVNFUkdVThABEg0KCVBMQVNNQUdVThACEgwK",
            "CFNIRUxMR1VOEAMSDgoKTUlTU0lMRUdVThAEEgoKBkFSQ0dVThAFKmIKD0Nv",
            "bnN0cnVjdG9yVHlwZRIZChVOVUxMX0NPTlNUUlVDVE9SX1RZUEUQABIQCgxD",
            "T05TVFJVQ1RPUjEQARIQCgxDT05TVFJVQ1RPUjIQAhIQCgxDT05TVFJVQ1RP",
            "UjMQAypECglBcm1vclR5cGUSEwoPTlVMTF9BUk1PUl9UWVBFEAASCgoGQVJN",
            "T1IxEAESCgoGQVJNT1IyEAISCgoGQVJNT1IzEAMqSQoKU2hpZWxkVHlwZRIU",
            "ChBOVUxMX1NISUVMRF9UWVBFEAASCwoHU0hJRUxEMRABEgsKB1NISUVMRDIQ",
            "AhILCgdTSElFTEQzEAMqUwoMUHJvZHVjZXJUeXBlEhYKEk5VTExfUFJPRFVD",
            "RVJfVFlQRRAAEg0KCVBST0RVQ0VSMRABEg0KCVBST0RVQ0VSMhACEg0KCVBS",
            "T0RVQ0VSMxADKo4DCgpNb2R1bGVUeXBlEhQKEE5VTExfTU9EVUxFX1RZUEUQ",
            "ABIUChBNT0RVTEVfUFJPRFVDRVIxEAESFAoQTU9EVUxFX1BST0RVQ0VSMhAC",
            "EhQKEE1PRFVMRV9QUk9EVUNFUjMQAxIXChNNT0RVTEVfQ09OU1RSVUNUT1Ix",
            "EAQSFwoTTU9EVUxFX0NPTlNUUlVDVE9SMhAFEhcKE01PRFVMRV9DT05TVFJV",
            "Q1RPUjMQBhIRCg1NT0RVTEVfQVJNT1IxEAcSEQoNTU9EVUxFX0FSTU9SMhAI",
            "EhEKDU1PRFVMRV9BUk1PUjMQCRISCg5NT0RVTEVfU0hJRUxEMRAKEhIKDk1P",
            "RFVMRV9TSElFTEQyEAsSEgoOTU9EVUxFX1NISUVMRDMQDBITCg9NT0RVTEVf",
            "TEFTRVJHVU4QDRIUChBNT0RVTEVfUExBU01BR1VOEA4SEwoPTU9EVUxFX1NI",
            "RUxMR1VOEA8SFQoRTU9EVUxFX01JU1NJTEVHVU4QEBIRCg1NT0RVTEVfQVJD",
            "R1VOEBEqWgoKQnVsbGV0VHlwZRIUChBOVUxMX0JVTExFVF9UWVBFEAASCQoF",
            "TEFTRVIQARIKCgZQTEFTTUEQAhIJCgVTSEVMTBADEgsKB01JU1NJTEUQBBIH",
            "CgNBUkMQBSpUChBDb25zdHJ1Y3Rpb25UeXBlEhoKFk5VTExfQ09OU1RSVUNU",
            "SU9OX1RZUEUQABILCgdGQUNUT1JZEAESDQoJQ09NTVVOSVRZEAISCAoERk9S",
            "VBADKjQKCE5ld3NUeXBlEhIKDk5VTExfTkVXU19UWVBFEAASCAoEVEVYVBAB",
            "EgoKBkJJTkFSWRACKi4KClBsYXllclRlYW0SDQoJTlVMTF9URUFNEAASBwoD",
            "UkVEEAESCAoEQkxVRRACYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Protobuf.GameState), typeof(global::Protobuf.PlaceType), typeof(global::Protobuf.ShapeType), typeof(global::Protobuf.PlayerType), typeof(global::Protobuf.ShipType), typeof(global::Protobuf.ShipState), typeof(global::Protobuf.WeaponType), typeof(global::Protobuf.ConstructorType), typeof(global::Protobuf.ArmorType), typeof(global::Protobuf.ShieldType), typeof(global::Protobuf.ProducerType), typeof(global::Protobuf.ModuleType), typeof(global::Protobuf.BulletType), typeof(global::Protobuf.ConstructionType), typeof(global::Protobuf.NewsType), typeof(global::Protobuf.PlayerTeam), }, null, null));
    }
    #endregion

  }
  #region Enums
  /// <summary>
  /// 游戏进行状态
  /// </summary>
  public enum GameState {
    [pbr::OriginalName("NULL_GAME_STATE")] NullGameState = 0,
    [pbr::OriginalName("GAME_START")] GameStart = 1,
    [pbr::OriginalName("GAME_RUNNING")] GameRunning = 2,
    [pbr::OriginalName("GAME_END")] GameEnd = 3,
  }

  public enum PlaceType {
    [pbr::OriginalName("NULL_PLACE_TYPE")] NullPlaceType = 0,
    [pbr::OriginalName("HOME")] Home = 1,
    [pbr::OriginalName("SPACE")] Space = 2,
    [pbr::OriginalName("RUIN")] Ruin = 3,
    [pbr::OriginalName("SHADOW")] Shadow = 4,
    [pbr::OriginalName("ASTEROID")] Asteroid = 5,
    [pbr::OriginalName("RESOURCE")] Resource = 6,
    [pbr::OriginalName("CONSTRUCTION")] Construction = 7,
    [pbr::OriginalName("WORMHOLE")] Wormhole = 8,
  }

  public enum ShapeType {
    [pbr::OriginalName("NULL_SHAPE_TYPE")] NullShapeType = 0,
    [pbr::OriginalName("CIRCLE")] Circle = 1,
    [pbr::OriginalName("SQUARE")] Square = 2,
  }

  public enum PlayerType {
    [pbr::OriginalName("NULL_PLAYER_TYPE")] NullPlayerType = 0,
    [pbr::OriginalName("SHIP")] Ship = 1,
    [pbr::OriginalName("TEAM")] Team = 2,
  }

  public enum ShipType {
    [pbr::OriginalName("NULL_SHIP_TYPE")] NullShipType = 0,
    [pbr::OriginalName("CIVILIAN_SHIP")] CivilianShip = 1,
    [pbr::OriginalName("MILITARY_SHIP")] MilitaryShip = 2,
    [pbr::OriginalName("FLAG_SHIP")] FlagShip = 3,
  }

  public enum ShipState {
    [pbr::OriginalName("NULL_STATUS")] NullStatus = 0,
    [pbr::OriginalName("IDLE")] Idle = 1,
    [pbr::OriginalName("PRODUCING")] Producing = 2,
    [pbr::OriginalName("CONSTRUCTING")] Constructing = 3,
    [pbr::OriginalName("RECOVERING")] Recovering = 4,
    [pbr::OriginalName("RECYCLING")] Recycling = 5,
    [pbr::OriginalName("ATTACKING")] Attacking = 6,
    [pbr::OriginalName("SWINGING")] Swinging = 7,
    [pbr::OriginalName("STUNNED")] Stunned = 8,
    [pbr::OriginalName("MOVING")] Moving = 9,
  }

  public enum WeaponType {
    [pbr::OriginalName("NULL_WEAPON_TYPE")] NullWeaponType = 0,
    [pbr::OriginalName("LASERGUN")] Lasergun = 1,
    [pbr::OriginalName("PLASMAGUN")] Plasmagun = 2,
    [pbr::OriginalName("SHELLGUN")] Shellgun = 3,
    [pbr::OriginalName("MISSILEGUN")] Missilegun = 4,
    [pbr::OriginalName("ARCGUN")] Arcgun = 5,
  }

  public enum ConstructorType {
    [pbr::OriginalName("NULL_CONSTRUCTOR_TYPE")] NullConstructorType = 0,
    [pbr::OriginalName("CONSTRUCTOR1")] Constructor1 = 1,
    [pbr::OriginalName("CONSTRUCTOR2")] Constructor2 = 2,
    [pbr::OriginalName("CONSTRUCTOR3")] Constructor3 = 3,
  }

  public enum ArmorType {
    [pbr::OriginalName("NULL_ARMOR_TYPE")] NullArmorType = 0,
    [pbr::OriginalName("ARMOR1")] Armor1 = 1,
    [pbr::OriginalName("ARMOR2")] Armor2 = 2,
    [pbr::OriginalName("ARMOR3")] Armor3 = 3,
  }

  public enum ShieldType {
    [pbr::OriginalName("NULL_SHIELD_TYPE")] NullShieldType = 0,
    [pbr::OriginalName("SHIELD1")] Shield1 = 1,
    [pbr::OriginalName("SHIELD2")] Shield2 = 2,
    [pbr::OriginalName("SHIELD3")] Shield3 = 3,
  }

  public enum ProducerType {
    [pbr::OriginalName("NULL_PRODUCER_TYPE")] NullProducerType = 0,
    [pbr::OriginalName("PRODUCER1")] Producer1 = 1,
    [pbr::OriginalName("PRODUCER2")] Producer2 = 2,
    [pbr::OriginalName("PRODUCER3")] Producer3 = 3,
  }

  public enum ModuleType {
    [pbr::OriginalName("NULL_MODULE_TYPE")] NullModuleType = 0,
    [pbr::OriginalName("MODULE_PRODUCER1")] ModuleProducer1 = 1,
    [pbr::OriginalName("MODULE_PRODUCER2")] ModuleProducer2 = 2,
    [pbr::OriginalName("MODULE_PRODUCER3")] ModuleProducer3 = 3,
    [pbr::OriginalName("MODULE_CONSTRUCTOR1")] ModuleConstructor1 = 4,
    [pbr::OriginalName("MODULE_CONSTRUCTOR2")] ModuleConstructor2 = 5,
    [pbr::OriginalName("MODULE_CONSTRUCTOR3")] ModuleConstructor3 = 6,
    [pbr::OriginalName("MODULE_ARMOR1")] ModuleArmor1 = 7,
    [pbr::OriginalName("MODULE_ARMOR2")] ModuleArmor2 = 8,
    [pbr::OriginalName("MODULE_ARMOR3")] ModuleArmor3 = 9,
    [pbr::OriginalName("MODULE_SHIELD1")] ModuleShield1 = 10,
    [pbr::OriginalName("MODULE_SHIELD2")] ModuleShield2 = 11,
    [pbr::OriginalName("MODULE_SHIELD3")] ModuleShield3 = 12,
    [pbr::OriginalName("MODULE_LASERGUN")] ModuleLasergun = 13,
    [pbr::OriginalName("MODULE_PLASMAGUN")] ModulePlasmagun = 14,
    [pbr::OriginalName("MODULE_SHELLGUN")] ModuleShellgun = 15,
    [pbr::OriginalName("MODULE_MISSILEGUN")] ModuleMissilegun = 16,
    [pbr::OriginalName("MODULE_ARCGUN")] ModuleArcgun = 17,
  }

  public enum BulletType {
    [pbr::OriginalName("NULL_BULLET_TYPE")] NullBulletType = 0,
    [pbr::OriginalName("LASER")] Laser = 1,
    [pbr::OriginalName("PLASMA")] Plasma = 2,
    [pbr::OriginalName("SHELL")] Shell = 3,
    [pbr::OriginalName("MISSILE")] Missile = 4,
    [pbr::OriginalName("ARC")] Arc = 5,
  }

  public enum ConstructionType {
    [pbr::OriginalName("NULL_CONSTRUCTION_TYPE")] NullConstructionType = 0,
    [pbr::OriginalName("FACTORY")] Factory = 1,
    [pbr::OriginalName("COMMUNITY")] Community = 2,
    [pbr::OriginalName("FORT")] Fort = 3,
  }

  public enum NewsType {
    [pbr::OriginalName("NULL_NEWS_TYPE")] NullNewsType = 0,
    [pbr::OriginalName("TEXT")] Text = 1,
    [pbr::OriginalName("BINARY")] Binary = 2,
  }

  public enum PlayerTeam {
    [pbr::OriginalName("NULL_TEAM")] NullTeam = 0,
    [pbr::OriginalName("RED")] Red = 1,
    [pbr::OriginalName("BLUE")] Blue = 2,
  }

  #endregion

}

#endregion Designer generated code
