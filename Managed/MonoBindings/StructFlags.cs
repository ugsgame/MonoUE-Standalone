// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealEngine.Runtime
{
    // mirrors STRUCT_* flags in Engine/Source/Runtime/CoreUObject/Public/UObject/Class.h
    // If these change enough may be worth doing a regex of Class.h to generate this enum as a msbuild task.
#if CLSCOMPLIANT
    [Flags, CLSCompliant(false)]
#else
    [Flags]
#endif
    public enum StructFlags : ulong
    {
        // State flags.
        None = 0x00000000,
        Native = 0x00000001,

        ///<summary>If set, this struct will be compared using native code</summary>
        IdenticalNative = 0x00000002,

        HasInstancedReference = 0x00000004,

        NoExport = 0x00000008,

        /// <summary>Indicates that this struct should always be serialized as a single unit</summary>
        Atomic = 0x00000010,

        /// <summary>Indicates that this struct uses binary serialization; it is unsafe to add/remove members from this struct without incrementing the package version</summary>
        Immutable = 0x00000020,

        /// <summary>If set, native code needs to be run to find referenced objects</summary>
        AddStructReferencedObjects = 0x00000040,

        /// <summary>Indicates that this struct should be exportable/importable at the DLL layer.  Base structs must also be exportable for this to work.</summary>
        RequiredAPI = 0x00000200,

        /// <summary>If set, this struct will be serialized using the CPP net serializer</summary>
        NetSerializeNative = 0x00000400,

        /// <summary>If set, this struct will be serialized using the CPP serializer</summary>
        SerializeNative = 0x00000800,

        /// <summary>If set, this struct will be copied using the CPP operator=</summary>
        CopyNative = 0x00001000,

        /// <summary>If set, this struct will be copied using memcpy</summary>
        IsPlainOldData = 0x00002000,

        /// <summary>If set, this struct has no destructor and non will be called. IsPlainOldData implies NoDestructor</summary>
        NoDestructor = 0x00004000,

        /// <summary>If set, this struct will not be constructed because it is assumed that memory is zero before construction.</summary>
        ZeroConstructor = 0x00008000,

        /// <summary>If set, native code will be used to export text</summary>
        ExportTextItemNative = 0x00010000,

        /// <summary>If set, native code will be used to export text</summary>
        ImportTextItemNative = 0x00020000,

        /// <summary>If set, this struct will have PostSerialize called on it after CPP serializer or tagged property serialization is complete</summary>
        PostSerializeNative = 0x00040000,

        /// <summary>If set, this struct will have SerializeFromMismatchedTag called on it if a mismatched tag is encountered.</summary>
        SerializeFromMismatchedTag = 0x00080000,

        /// <summary>If set, this struct will be serialized using the CPP net delta serializer</summary>
        NetDeltaSerializeNative = 0x00100000,

        /// <summary>If set, this struct will be have PostScriptConstruct called on it after a temporary object is constructed in a running blueprint</summary>
        PostScriptConstruct = 0x00200000,

        /// <summary>If set, this struct can share net serialization state across connections</summary>
        NetSharedSerialization = 0x00400000,

        /// <summary>Struct flags that are automatically inherited</summary>
        Inherit = HasInstancedReference | Atomic,

        /// <summary>Flags that are always computed, never loaded or done with code generation</summary>
        ComputedFlags = NetDeltaSerializeNative | NetSerializeNative | SerializeNative | PostSerializeNative | CopyNative | IsPlainOldData | NoDestructor | ZeroConstructor | IdenticalNative | AddStructReferencedObjects | ExportTextItemNative | ImportTextItemNative | SerializeFromMismatchedTag | PostScriptConstruct | NetSharedSerialization
    };
}
