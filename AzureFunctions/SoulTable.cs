// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: SoulTable.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MokomoGames.Protobuf {

  /// <summary>Holder for reflection information generated from SoulTable.proto</summary>
  public static partial class SoulTableReflection {

    #region Descriptor
    /// <summary>File descriptor for SoulTable.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SoulTableReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg9Tb3VsVGFibGUucHJvdG8SBWVjaXR5GgxCYXR0bGUucHJvdG8ihwIKD1Nv",
            "dWxUYWJsZVJlY29yZBIKCgJubxgBIAEoDRIUCgxhbm90aGVyX25hbWUYAiAB",
            "KAkSDAoEbmFtZRgDIAEoCRIiCglzb3VsX3R5cGUYBCABKA4yDy5lY2l0eS5T",
            "b3VsVHlwZRIOCgZyYXJpdHkYBSABKA0SIwoJYXR0cmlidXRlGAYgASgOMhAu",
            "ZWNpdHkuQXR0cmlidXRlEgoKAmN2GAcgASgJEgwKBGNvc3QYCCABKA0SGQoR",
            "bm9ybWFsX3NraWxsX3R5cGUYCSABKA0SGQoRcmVhZGVyX3NraWxsX3R5cGUY",
            "CiABKA0SGwoTY2hhcmFjdGVyX2ljb25fbmFtZRgLIAEoCSI0CglTb3VsVGFi",
            "bGUSJwoHcmVjb3JkcxgBIAMoCzIWLmVjaXR5LlNvdWxUYWJsZVJlY29yZEIX",
            "qgIUTW9rb21vR2FtZXMuUHJvdG9idWZiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::MokomoGames.Protobuf.BattleReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MokomoGames.Protobuf.SoulTableRecord), global::MokomoGames.Protobuf.SoulTableRecord.Parser, new[]{ "No", "AnotherName", "Name", "SoulType", "Rarity", "Attribute", "Cv", "Cost", "NormalSkillType", "ReaderSkillType", "CharacterIconName" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MokomoGames.Protobuf.SoulTable), global::MokomoGames.Protobuf.SoulTable.Parser, new[]{ "Records" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class SoulTableRecord : pb::IMessage<SoulTableRecord> {
    private static readonly pb::MessageParser<SoulTableRecord> _parser = new pb::MessageParser<SoulTableRecord>(() => new SoulTableRecord());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SoulTableRecord> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MokomoGames.Protobuf.SoulTableReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SoulTableRecord() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SoulTableRecord(SoulTableRecord other) : this() {
      no_ = other.no_;
      anotherName_ = other.anotherName_;
      name_ = other.name_;
      soulType_ = other.soulType_;
      rarity_ = other.rarity_;
      attribute_ = other.attribute_;
      cv_ = other.cv_;
      cost_ = other.cost_;
      normalSkillType_ = other.normalSkillType_;
      readerSkillType_ = other.readerSkillType_;
      characterIconName_ = other.characterIconName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SoulTableRecord Clone() {
      return new SoulTableRecord(this);
    }

    /// <summary>Field number for the "no" field.</summary>
    public const int NoFieldNumber = 1;
    private uint no_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint No {
      get { return no_; }
      set {
        no_ = value;
      }
    }

    /// <summary>Field number for the "another_name" field.</summary>
    public const int AnotherNameFieldNumber = 2;
    private string anotherName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string AnotherName {
      get { return anotherName_; }
      set {
        anotherName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 3;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "soul_type" field.</summary>
    public const int SoulTypeFieldNumber = 4;
    private global::MokomoGames.Protobuf.SoulType soulType_ = global::MokomoGames.Protobuf.SoulType.Unknown;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MokomoGames.Protobuf.SoulType SoulType {
      get { return soulType_; }
      set {
        soulType_ = value;
      }
    }

    /// <summary>Field number for the "rarity" field.</summary>
    public const int RarityFieldNumber = 5;
    private uint rarity_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Rarity {
      get { return rarity_; }
      set {
        rarity_ = value;
      }
    }

    /// <summary>Field number for the "attribute" field.</summary>
    public const int AttributeFieldNumber = 6;
    private global::MokomoGames.Protobuf.Attribute attribute_ = global::MokomoGames.Protobuf.Attribute.Unknown;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MokomoGames.Protobuf.Attribute Attribute {
      get { return attribute_; }
      set {
        attribute_ = value;
      }
    }

    /// <summary>Field number for the "cv" field.</summary>
    public const int CvFieldNumber = 7;
    private string cv_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Cv {
      get { return cv_; }
      set {
        cv_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "cost" field.</summary>
    public const int CostFieldNumber = 8;
    private uint cost_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Cost {
      get { return cost_; }
      set {
        cost_ = value;
      }
    }

    /// <summary>Field number for the "normal_skill_type" field.</summary>
    public const int NormalSkillTypeFieldNumber = 9;
    private uint normalSkillType_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint NormalSkillType {
      get { return normalSkillType_; }
      set {
        normalSkillType_ = value;
      }
    }

    /// <summary>Field number for the "reader_skill_type" field.</summary>
    public const int ReaderSkillTypeFieldNumber = 10;
    private uint readerSkillType_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint ReaderSkillType {
      get { return readerSkillType_; }
      set {
        readerSkillType_ = value;
      }
    }

    /// <summary>Field number for the "character_icon_name" field.</summary>
    public const int CharacterIconNameFieldNumber = 11;
    private string characterIconName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CharacterIconName {
      get { return characterIconName_; }
      set {
        characterIconName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SoulTableRecord);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SoulTableRecord other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (No != other.No) return false;
      if (AnotherName != other.AnotherName) return false;
      if (Name != other.Name) return false;
      if (SoulType != other.SoulType) return false;
      if (Rarity != other.Rarity) return false;
      if (Attribute != other.Attribute) return false;
      if (Cv != other.Cv) return false;
      if (Cost != other.Cost) return false;
      if (NormalSkillType != other.NormalSkillType) return false;
      if (ReaderSkillType != other.ReaderSkillType) return false;
      if (CharacterIconName != other.CharacterIconName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (No != 0) hash ^= No.GetHashCode();
      if (AnotherName.Length != 0) hash ^= AnotherName.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (SoulType != global::MokomoGames.Protobuf.SoulType.Unknown) hash ^= SoulType.GetHashCode();
      if (Rarity != 0) hash ^= Rarity.GetHashCode();
      if (Attribute != global::MokomoGames.Protobuf.Attribute.Unknown) hash ^= Attribute.GetHashCode();
      if (Cv.Length != 0) hash ^= Cv.GetHashCode();
      if (Cost != 0) hash ^= Cost.GetHashCode();
      if (NormalSkillType != 0) hash ^= NormalSkillType.GetHashCode();
      if (ReaderSkillType != 0) hash ^= ReaderSkillType.GetHashCode();
      if (CharacterIconName.Length != 0) hash ^= CharacterIconName.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (No != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(No);
      }
      if (AnotherName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(AnotherName);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Name);
      }
      if (SoulType != global::MokomoGames.Protobuf.SoulType.Unknown) {
        output.WriteRawTag(32);
        output.WriteEnum((int) SoulType);
      }
      if (Rarity != 0) {
        output.WriteRawTag(40);
        output.WriteUInt32(Rarity);
      }
      if (Attribute != global::MokomoGames.Protobuf.Attribute.Unknown) {
        output.WriteRawTag(48);
        output.WriteEnum((int) Attribute);
      }
      if (Cv.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Cv);
      }
      if (Cost != 0) {
        output.WriteRawTag(64);
        output.WriteUInt32(Cost);
      }
      if (NormalSkillType != 0) {
        output.WriteRawTag(72);
        output.WriteUInt32(NormalSkillType);
      }
      if (ReaderSkillType != 0) {
        output.WriteRawTag(80);
        output.WriteUInt32(ReaderSkillType);
      }
      if (CharacterIconName.Length != 0) {
        output.WriteRawTag(90);
        output.WriteString(CharacterIconName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (No != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(No);
      }
      if (AnotherName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(AnotherName);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (SoulType != global::MokomoGames.Protobuf.SoulType.Unknown) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) SoulType);
      }
      if (Rarity != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Rarity);
      }
      if (Attribute != global::MokomoGames.Protobuf.Attribute.Unknown) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Attribute);
      }
      if (Cv.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Cv);
      }
      if (Cost != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Cost);
      }
      if (NormalSkillType != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(NormalSkillType);
      }
      if (ReaderSkillType != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ReaderSkillType);
      }
      if (CharacterIconName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CharacterIconName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SoulTableRecord other) {
      if (other == null) {
        return;
      }
      if (other.No != 0) {
        No = other.No;
      }
      if (other.AnotherName.Length != 0) {
        AnotherName = other.AnotherName;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.SoulType != global::MokomoGames.Protobuf.SoulType.Unknown) {
        SoulType = other.SoulType;
      }
      if (other.Rarity != 0) {
        Rarity = other.Rarity;
      }
      if (other.Attribute != global::MokomoGames.Protobuf.Attribute.Unknown) {
        Attribute = other.Attribute;
      }
      if (other.Cv.Length != 0) {
        Cv = other.Cv;
      }
      if (other.Cost != 0) {
        Cost = other.Cost;
      }
      if (other.NormalSkillType != 0) {
        NormalSkillType = other.NormalSkillType;
      }
      if (other.ReaderSkillType != 0) {
        ReaderSkillType = other.ReaderSkillType;
      }
      if (other.CharacterIconName.Length != 0) {
        CharacterIconName = other.CharacterIconName;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            No = input.ReadUInt32();
            break;
          }
          case 18: {
            AnotherName = input.ReadString();
            break;
          }
          case 26: {
            Name = input.ReadString();
            break;
          }
          case 32: {
            SoulType = (global::MokomoGames.Protobuf.SoulType) input.ReadEnum();
            break;
          }
          case 40: {
            Rarity = input.ReadUInt32();
            break;
          }
          case 48: {
            Attribute = (global::MokomoGames.Protobuf.Attribute) input.ReadEnum();
            break;
          }
          case 58: {
            Cv = input.ReadString();
            break;
          }
          case 64: {
            Cost = input.ReadUInt32();
            break;
          }
          case 72: {
            NormalSkillType = input.ReadUInt32();
            break;
          }
          case 80: {
            ReaderSkillType = input.ReadUInt32();
            break;
          }
          case 90: {
            CharacterIconName = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class SoulTable : pb::IMessage<SoulTable> {
    private static readonly pb::MessageParser<SoulTable> _parser = new pb::MessageParser<SoulTable>(() => new SoulTable());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SoulTable> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MokomoGames.Protobuf.SoulTableReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SoulTable() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SoulTable(SoulTable other) : this() {
      records_ = other.records_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SoulTable Clone() {
      return new SoulTable(this);
    }

    /// <summary>Field number for the "records" field.</summary>
    public const int RecordsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::MokomoGames.Protobuf.SoulTableRecord> _repeated_records_codec
        = pb::FieldCodec.ForMessage(10, global::MokomoGames.Protobuf.SoulTableRecord.Parser);
    private readonly pbc::RepeatedField<global::MokomoGames.Protobuf.SoulTableRecord> records_ = new pbc::RepeatedField<global::MokomoGames.Protobuf.SoulTableRecord>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::MokomoGames.Protobuf.SoulTableRecord> Records {
      get { return records_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SoulTable);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SoulTable other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!records_.Equals(other.records_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= records_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      records_.WriteTo(output, _repeated_records_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += records_.CalculateSize(_repeated_records_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SoulTable other) {
      if (other == null) {
        return;
      }
      records_.Add(other.records_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            records_.AddEntriesFrom(input, _repeated_records_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
