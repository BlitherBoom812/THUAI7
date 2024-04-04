// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: MessageType.proto

#ifndef GOOGLE_PROTOBUF_INCLUDED_MessageType_2eproto
#define GOOGLE_PROTOBUF_INCLUDED_MessageType_2eproto

#include <limits>
#include <string>

#include <google/protobuf/port_def.inc>
#if PROTOBUF_VERSION < 3021000
#error This file was generated by a newer version of protoc which is
#error incompatible with your Protocol Buffer headers. Please update
#error your headers.
#endif
#if 3021006 < PROTOBUF_MIN_PROTOC_VERSION
#error This file was generated by an older version of protoc which is
#error incompatible with your Protocol Buffer headers. Please
#error regenerate this file with a newer version of protoc.
#endif

#include <google/protobuf/port_undef.inc>
#include <google/protobuf/io/coded_stream.h>
#include <google/protobuf/arena.h>
#include <google/protobuf/arenastring.h>
#include <google/protobuf/generated_message_util.h>
#include <google/protobuf/metadata_lite.h>
#include <google/protobuf/generated_message_reflection.h>
#include <google/protobuf/repeated_field.h>  // IWYU pragma: export
#include <google/protobuf/extension_set.h>   // IWYU pragma: export
#include <google/protobuf/generated_enum_reflection.h>
// @@protoc_insertion_point(includes)
#include <google/protobuf/port_def.inc>
#define PROTOBUF_INTERNAL_EXPORT_MessageType_2eproto
PROTOBUF_NAMESPACE_OPEN
namespace internal
{
    class AnyMetadata;
}  // namespace internal
PROTOBUF_NAMESPACE_CLOSE

// Internal implementation detail -- do not use these members.
struct TableStruct_MessageType_2eproto
{
    static const uint32_t offsets[];
};
extern const ::PROTOBUF_NAMESPACE_ID::internal::DescriptorTable descriptor_table_MessageType_2eproto;
PROTOBUF_NAMESPACE_OPEN
PROTOBUF_NAMESPACE_CLOSE
namespace protobuf
{

    enum GameState : int
    {
        NULL_GAME_STATE = 0,
        GAME_START = 1,
        GAME_RUNNING = 2,
        GAME_END = 3,
        GameState_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        GameState_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool GameState_IsValid(int value);
    constexpr GameState GameState_MIN = NULL_GAME_STATE;
    constexpr GameState GameState_MAX = GAME_END;
    constexpr int GameState_ARRAYSIZE = GameState_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* GameState_descriptor();
    template<typename T>
    inline const std::string& GameState_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, GameState>::value || ::std::is_integral<T>::value, "Incorrect type passed to function GameState_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            GameState_descriptor(), enum_t_value
        );
    }
    inline bool GameState_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, GameState* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<GameState>(
            GameState_descriptor(), name, value
        );
    }
    enum PlaceType : int
    {
        NULL_PLACE_TYPE = 0,
        HOME = 1,
        SPACE = 2,
        RUIN = 3,
        SHADOW = 4,
        ASTEROID = 5,
        RESOURCE = 6,
        CONSTRUCTION = 7,
        WORMHOLE = 8,
        PlaceType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        PlaceType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool PlaceType_IsValid(int value);
    constexpr PlaceType PlaceType_MIN = NULL_PLACE_TYPE;
    constexpr PlaceType PlaceType_MAX = WORMHOLE;
    constexpr int PlaceType_ARRAYSIZE = PlaceType_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* PlaceType_descriptor();
    template<typename T>
    inline const std::string& PlaceType_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, PlaceType>::value || ::std::is_integral<T>::value, "Incorrect type passed to function PlaceType_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            PlaceType_descriptor(), enum_t_value
        );
    }
    inline bool PlaceType_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, PlaceType* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<PlaceType>(
            PlaceType_descriptor(), name, value
        );
    }
    enum ShapeType : int
    {
        NULL_SHAPE_TYPE = 0,
        CIRCLE = 1,
        SQUARE = 2,
        ShapeType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        ShapeType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool ShapeType_IsValid(int value);
    constexpr ShapeType ShapeType_MIN = NULL_SHAPE_TYPE;
    constexpr ShapeType ShapeType_MAX = SQUARE;
    constexpr int ShapeType_ARRAYSIZE = ShapeType_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ShapeType_descriptor();
    template<typename T>
    inline const std::string& ShapeType_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, ShapeType>::value || ::std::is_integral<T>::value, "Incorrect type passed to function ShapeType_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            ShapeType_descriptor(), enum_t_value
        );
    }
    inline bool ShapeType_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, ShapeType* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<ShapeType>(
            ShapeType_descriptor(), name, value
        );
    }
    enum PlayerType : int
    {
        NULL_PLAYER_TYPE = 0,
        SHIP = 1,
        TEAM = 2,
        PlayerType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        PlayerType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool PlayerType_IsValid(int value);
    constexpr PlayerType PlayerType_MIN = NULL_PLAYER_TYPE;
    constexpr PlayerType PlayerType_MAX = TEAM;
    constexpr int PlayerType_ARRAYSIZE = PlayerType_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* PlayerType_descriptor();
    template<typename T>
    inline const std::string& PlayerType_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, PlayerType>::value || ::std::is_integral<T>::value, "Incorrect type passed to function PlayerType_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            PlayerType_descriptor(), enum_t_value
        );
    }
    inline bool PlayerType_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, PlayerType* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<PlayerType>(
            PlayerType_descriptor(), name, value
        );
    }
    enum ShipType : int
    {
        NULL_SHIP_TYPE = 0,
        CIVILIAN_SHIP = 1,
        MILITARY_SHIP = 2,
        FLAG_SHIP = 3,
        ShipType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        ShipType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool ShipType_IsValid(int value);
    constexpr ShipType ShipType_MIN = NULL_SHIP_TYPE;
    constexpr ShipType ShipType_MAX = FLAG_SHIP;
    constexpr int ShipType_ARRAYSIZE = ShipType_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ShipType_descriptor();
    template<typename T>
    inline const std::string& ShipType_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, ShipType>::value || ::std::is_integral<T>::value, "Incorrect type passed to function ShipType_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            ShipType_descriptor(), enum_t_value
        );
    }
    inline bool ShipType_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, ShipType* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<ShipType>(
            ShipType_descriptor(), name, value
        );
    }
    enum ShipState : int
    {
        NULL_STATUS = 0,
        IDLE = 1,
        PRODUCING = 2,
        CONSTRUCTING = 3,
        RECOVERING = 4,
        RECYCLING = 5,
        ATTACKING = 6,
        SWINGING = 7,
        STUNNED = 8,
        MOVING = 9,
        ShipState_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        ShipState_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool ShipState_IsValid(int value);
    constexpr ShipState ShipState_MIN = NULL_STATUS;
    constexpr ShipState ShipState_MAX = MOVING;
    constexpr int ShipState_ARRAYSIZE = ShipState_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ShipState_descriptor();
    template<typename T>
    inline const std::string& ShipState_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, ShipState>::value || ::std::is_integral<T>::value, "Incorrect type passed to function ShipState_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            ShipState_descriptor(), enum_t_value
        );
    }
    inline bool ShipState_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, ShipState* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<ShipState>(
            ShipState_descriptor(), name, value
        );
    }
    enum WeaponType : int
    {
        NULL_WEAPON_TYPE = 0,
        LASERGUN = 1,
        PLASMAGUN = 2,
        SHELLGUN = 3,
        MISSILEGUN = 4,
        ARCGUN = 5,
        WeaponType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        WeaponType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool WeaponType_IsValid(int value);
    constexpr WeaponType WeaponType_MIN = NULL_WEAPON_TYPE;
    constexpr WeaponType WeaponType_MAX = ARCGUN;
    constexpr int WeaponType_ARRAYSIZE = WeaponType_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* WeaponType_descriptor();
    template<typename T>
    inline const std::string& WeaponType_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, WeaponType>::value || ::std::is_integral<T>::value, "Incorrect type passed to function WeaponType_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            WeaponType_descriptor(), enum_t_value
        );
    }
    inline bool WeaponType_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, WeaponType* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<WeaponType>(
            WeaponType_descriptor(), name, value
        );
    }
    enum ConstructorType : int
    {
        NULL_CONSTRUCTOR_TYPE = 0,
        CONSTRUCTOR1 = 1,
        CONSTRUCTOR2 = 2,
        CONSTRUCTOR3 = 3,
        ConstructorType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        ConstructorType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool ConstructorType_IsValid(int value);
    constexpr ConstructorType ConstructorType_MIN = NULL_CONSTRUCTOR_TYPE;
    constexpr ConstructorType ConstructorType_MAX = CONSTRUCTOR3;
    constexpr int ConstructorType_ARRAYSIZE = ConstructorType_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ConstructorType_descriptor();
    template<typename T>
    inline const std::string& ConstructorType_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, ConstructorType>::value || ::std::is_integral<T>::value, "Incorrect type passed to function ConstructorType_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            ConstructorType_descriptor(), enum_t_value
        );
    }
    inline bool ConstructorType_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, ConstructorType* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<ConstructorType>(
            ConstructorType_descriptor(), name, value
        );
    }
    enum ArmorType : int
    {
        NULL_ARMOR_TYPE = 0,
        ARMOR1 = 1,
        ARMOR2 = 2,
        ARMOR3 = 3,
        ArmorType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        ArmorType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool ArmorType_IsValid(int value);
    constexpr ArmorType ArmorType_MIN = NULL_ARMOR_TYPE;
    constexpr ArmorType ArmorType_MAX = ARMOR3;
    constexpr int ArmorType_ARRAYSIZE = ArmorType_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ArmorType_descriptor();
    template<typename T>
    inline const std::string& ArmorType_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, ArmorType>::value || ::std::is_integral<T>::value, "Incorrect type passed to function ArmorType_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            ArmorType_descriptor(), enum_t_value
        );
    }
    inline bool ArmorType_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, ArmorType* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<ArmorType>(
            ArmorType_descriptor(), name, value
        );
    }
    enum ShieldType : int
    {
        NULL_SHIELD_TYPE = 0,
        SHIELD1 = 1,
        SHIELD2 = 2,
        SHIELD3 = 3,
        ShieldType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        ShieldType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool ShieldType_IsValid(int value);
    constexpr ShieldType ShieldType_MIN = NULL_SHIELD_TYPE;
    constexpr ShieldType ShieldType_MAX = SHIELD3;
    constexpr int ShieldType_ARRAYSIZE = ShieldType_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ShieldType_descriptor();
    template<typename T>
    inline const std::string& ShieldType_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, ShieldType>::value || ::std::is_integral<T>::value, "Incorrect type passed to function ShieldType_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            ShieldType_descriptor(), enum_t_value
        );
    }
    inline bool ShieldType_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, ShieldType* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<ShieldType>(
            ShieldType_descriptor(), name, value
        );
    }
    enum ProducerType : int
    {
        NULL_PRODUCER_TYPE = 0,
        PRODUCER1 = 1,
        PRODUCER2 = 2,
        PRODUCER3 = 3,
        ProducerType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        ProducerType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool ProducerType_IsValid(int value);
    constexpr ProducerType ProducerType_MIN = NULL_PRODUCER_TYPE;
    constexpr ProducerType ProducerType_MAX = PRODUCER3;
    constexpr int ProducerType_ARRAYSIZE = ProducerType_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ProducerType_descriptor();
    template<typename T>
    inline const std::string& ProducerType_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, ProducerType>::value || ::std::is_integral<T>::value, "Incorrect type passed to function ProducerType_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            ProducerType_descriptor(), enum_t_value
        );
    }
    inline bool ProducerType_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, ProducerType* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<ProducerType>(
            ProducerType_descriptor(), name, value
        );
    }
    enum ModuleType : int
    {
        NULL_MODULE_TYPE = 0,
        MODULE_PRODUCER1 = 1,
        MODULE_PRODUCER2 = 2,
        MODULE_PRODUCER3 = 3,
        MODULE_CONSTRUCTOR1 = 4,
        MODULE_CONSTRUCTOR2 = 5,
        MODULE_CONSTRUCTOR3 = 6,
        MODULE_ARMOR1 = 7,
        MODULE_ARMOR2 = 8,
        MODULE_ARMOR3 = 9,
        MODULE_SHIELD1 = 10,
        MODULE_SHIELD2 = 11,
        MODULE_SHIELD3 = 12,
        MODULE_LASERGUN = 13,
        MODULE_PLASMAGUN = 14,
        MODULE_SHELLGUN = 15,
        MODULE_MISSILEGUN = 16,
        MODULE_ARCGUN = 17,
        ModuleType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        ModuleType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool ModuleType_IsValid(int value);
    constexpr ModuleType ModuleType_MIN = NULL_MODULE_TYPE;
    constexpr ModuleType ModuleType_MAX = MODULE_ARCGUN;
    constexpr int ModuleType_ARRAYSIZE = ModuleType_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ModuleType_descriptor();
    template<typename T>
    inline const std::string& ModuleType_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, ModuleType>::value || ::std::is_integral<T>::value, "Incorrect type passed to function ModuleType_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            ModuleType_descriptor(), enum_t_value
        );
    }
    inline bool ModuleType_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, ModuleType* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<ModuleType>(
            ModuleType_descriptor(), name, value
        );
    }
    enum BulletType : int
    {
        NULL_BULLET_TYPE = 0,
        LASER = 1,
        PLASMA = 2,
        SHELL = 3,
        MISSILE = 4,
        ARC = 5,
        BulletType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        BulletType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool BulletType_IsValid(int value);
    constexpr BulletType BulletType_MIN = NULL_BULLET_TYPE;
    constexpr BulletType BulletType_MAX = ARC;
    constexpr int BulletType_ARRAYSIZE = BulletType_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* BulletType_descriptor();
    template<typename T>
    inline const std::string& BulletType_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, BulletType>::value || ::std::is_integral<T>::value, "Incorrect type passed to function BulletType_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            BulletType_descriptor(), enum_t_value
        );
    }
    inline bool BulletType_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, BulletType* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<BulletType>(
            BulletType_descriptor(), name, value
        );
    }
    enum ConstructionType : int
    {
        NULL_CONSTRUCTION_TYPE = 0,
        FACTORY = 1,
        COMMUNITY = 2,
        FORT = 3,
        ConstructionType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        ConstructionType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool ConstructionType_IsValid(int value);
    constexpr ConstructionType ConstructionType_MIN = NULL_CONSTRUCTION_TYPE;
    constexpr ConstructionType ConstructionType_MAX = FORT;
    constexpr int ConstructionType_ARRAYSIZE = ConstructionType_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ConstructionType_descriptor();
    template<typename T>
    inline const std::string& ConstructionType_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, ConstructionType>::value || ::std::is_integral<T>::value, "Incorrect type passed to function ConstructionType_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            ConstructionType_descriptor(), enum_t_value
        );
    }
    inline bool ConstructionType_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, ConstructionType* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<ConstructionType>(
            ConstructionType_descriptor(), name, value
        );
    }
    enum NewsType : int
    {
        NULL_NEWS_TYPE = 0,
        TEXT = 1,
        BINARY = 2,
        NewsType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        NewsType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool NewsType_IsValid(int value);
    constexpr NewsType NewsType_MIN = NULL_NEWS_TYPE;
    constexpr NewsType NewsType_MAX = BINARY;
    constexpr int NewsType_ARRAYSIZE = NewsType_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* NewsType_descriptor();
    template<typename T>
    inline const std::string& NewsType_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, NewsType>::value || ::std::is_integral<T>::value, "Incorrect type passed to function NewsType_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            NewsType_descriptor(), enum_t_value
        );
    }
    inline bool NewsType_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, NewsType* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<NewsType>(
            NewsType_descriptor(), name, value
        );
    }
    enum PlayerTeam : int
    {
        NULL_TEAM = 0,
        RED = 1,
        BLUE = 2,
        PlayerTeam_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::min(),
        PlayerTeam_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<int32_t>::max()
    };
    bool PlayerTeam_IsValid(int value);
    constexpr PlayerTeam PlayerTeam_MIN = NULL_TEAM;
    constexpr PlayerTeam PlayerTeam_MAX = BLUE;
    constexpr int PlayerTeam_ARRAYSIZE = PlayerTeam_MAX + 1;

    const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* PlayerTeam_descriptor();
    template<typename T>
    inline const std::string& PlayerTeam_Name(T enum_t_value)
    {
        static_assert(::std::is_same<T, PlayerTeam>::value || ::std::is_integral<T>::value, "Incorrect type passed to function PlayerTeam_Name.");
        return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
            PlayerTeam_descriptor(), enum_t_value
        );
    }
    inline bool PlayerTeam_Parse(
        ::PROTOBUF_NAMESPACE_ID::ConstStringParam name, PlayerTeam* value
    )
    {
        return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<PlayerTeam>(
            PlayerTeam_descriptor(), name, value
        );
    }
    // ===================================================================

    // ===================================================================

    // ===================================================================

#ifdef __GNUC__
#pragma GCC diagnostic push
#pragma GCC diagnostic ignored "-Wstrict-aliasing"
#endif  // __GNUC__
#ifdef __GNUC__
#pragma GCC diagnostic pop
#endif  // __GNUC__

    // @@protoc_insertion_point(namespace_scope)

}  // namespace protobuf

PROTOBUF_NAMESPACE_OPEN

template<>
struct is_proto_enum<::protobuf::GameState> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::GameState>()
{
    return ::protobuf::GameState_descriptor();
}
template<>
struct is_proto_enum<::protobuf::PlaceType> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::PlaceType>()
{
    return ::protobuf::PlaceType_descriptor();
}
template<>
struct is_proto_enum<::protobuf::ShapeType> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::ShapeType>()
{
    return ::protobuf::ShapeType_descriptor();
}
template<>
struct is_proto_enum<::protobuf::PlayerType> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::PlayerType>()
{
    return ::protobuf::PlayerType_descriptor();
}
template<>
struct is_proto_enum<::protobuf::ShipType> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::ShipType>()
{
    return ::protobuf::ShipType_descriptor();
}
template<>
struct is_proto_enum<::protobuf::ShipState> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::ShipState>()
{
    return ::protobuf::ShipState_descriptor();
}
template<>
struct is_proto_enum<::protobuf::WeaponType> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::WeaponType>()
{
    return ::protobuf::WeaponType_descriptor();
}
template<>
struct is_proto_enum<::protobuf::ConstructorType> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::ConstructorType>()
{
    return ::protobuf::ConstructorType_descriptor();
}
template<>
struct is_proto_enum<::protobuf::ArmorType> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::ArmorType>()
{
    return ::protobuf::ArmorType_descriptor();
}
template<>
struct is_proto_enum<::protobuf::ShieldType> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::ShieldType>()
{
    return ::protobuf::ShieldType_descriptor();
}
template<>
struct is_proto_enum<::protobuf::ProducerType> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::ProducerType>()
{
    return ::protobuf::ProducerType_descriptor();
}
template<>
struct is_proto_enum<::protobuf::ModuleType> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::ModuleType>()
{
    return ::protobuf::ModuleType_descriptor();
}
template<>
struct is_proto_enum<::protobuf::BulletType> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::BulletType>()
{
    return ::protobuf::BulletType_descriptor();
}
template<>
struct is_proto_enum<::protobuf::ConstructionType> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::ConstructionType>()
{
    return ::protobuf::ConstructionType_descriptor();
}
template<>
struct is_proto_enum<::protobuf::NewsType> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::NewsType>()
{
    return ::protobuf::NewsType_descriptor();
}
template<>
struct is_proto_enum<::protobuf::PlayerTeam> : ::std::true_type
{
};
template<>
inline const EnumDescriptor* GetEnumDescriptor<::protobuf::PlayerTeam>()
{
    return ::protobuf::PlayerTeam_descriptor();
}

PROTOBUF_NAMESPACE_CLOSE

// @@protoc_insertion_point(global_scope)

#include <google/protobuf/port_undef.inc>
#endif  // GOOGLE_PROTOBUF_INCLUDED_GOOGLE_PROTOBUF_INCLUDED_MessageType_2eproto
