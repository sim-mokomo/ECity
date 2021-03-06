// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: protos/RankTable.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MokomoGames.Protobuf {

  /// <summary>Holder for reflection information generated from protos/RankTable.proto</summary>
  public static partial class RankTableReflection {

    #region Descriptor
    /// <summary>File descriptor for protos/RankTable.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static RankTableReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZwcm90b3MvUmFua1RhYmxlLnByb3RvEgVlY2l0eSJNCg9SYW5rVGFibGVS",
            "ZWNvcmQSDAoEcmFuaxgBIAEoDRIQCghtYXhfZnVlbBgCIAEoDRIaChJuZWVk",
            "X25leHRfcmFua19leHAYAyABKA0iNAoJUmFua1RhYmxlEicKB3JlY29yZHMY",
            "ASADKAsyFi5lY2l0eS5SYW5rVGFibGVSZWNvcmRCF6oCFE1va29tb0dhbWVz",
            "LlByb3RvYnVmYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MokomoGames.Protobuf.RankTableRecord), global::MokomoGames.Protobuf.RankTableRecord.Parser, new[]{ "Rank", "MaxFuel", "NeedNextRankExp" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MokomoGames.Protobuf.RankTable), global::MokomoGames.Protobuf.RankTable.Parser, new[]{ "Records" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class RankTableRecord : pb::IMessage<RankTableRecord> {
    private static readonly pb::MessageParser<RankTableRecord> _parser = new pb::MessageParser<RankTableRecord>(() => new RankTableRecord());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RankTableRecord> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MokomoGames.Protobuf.RankTableReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RankTableRecord() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RankTableRecord(RankTableRecord other) : this() {
      rank_ = other.rank_;
      maxFuel_ = other.maxFuel_;
      needNextRankExp_ = other.needNextRankExp_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RankTableRecord Clone() {
      return new RankTableRecord(this);
    }

    /// <summary>Field number for the "rank" field.</summary>
    public const int RankFieldNumber = 1;
    private uint rank_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Rank {
      get { return rank_; }
      set {
        rank_ = value;
      }
    }

    /// <summary>Field number for the "max_fuel" field.</summary>
    public const int MaxFuelFieldNumber = 2;
    private uint maxFuel_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint MaxFuel {
      get { return maxFuel_; }
      set {
        maxFuel_ = value;
      }
    }

    /// <summary>Field number for the "need_next_rank_exp" field.</summary>
    public const int NeedNextRankExpFieldNumber = 3;
    private uint needNextRankExp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint NeedNextRankExp {
      get { return needNextRankExp_; }
      set {
        needNextRankExp_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RankTableRecord);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RankTableRecord other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Rank != other.Rank) return false;
      if (MaxFuel != other.MaxFuel) return false;
      if (NeedNextRankExp != other.NeedNextRankExp) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Rank != 0) hash ^= Rank.GetHashCode();
      if (MaxFuel != 0) hash ^= MaxFuel.GetHashCode();
      if (NeedNextRankExp != 0) hash ^= NeedNextRankExp.GetHashCode();
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
      if (Rank != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(Rank);
      }
      if (MaxFuel != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(MaxFuel);
      }
      if (NeedNextRankExp != 0) {
        output.WriteRawTag(24);
        output.WriteUInt32(NeedNextRankExp);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Rank != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Rank);
      }
      if (MaxFuel != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(MaxFuel);
      }
      if (NeedNextRankExp != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(NeedNextRankExp);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RankTableRecord other) {
      if (other == null) {
        return;
      }
      if (other.Rank != 0) {
        Rank = other.Rank;
      }
      if (other.MaxFuel != 0) {
        MaxFuel = other.MaxFuel;
      }
      if (other.NeedNextRankExp != 0) {
        NeedNextRankExp = other.NeedNextRankExp;
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
            Rank = input.ReadUInt32();
            break;
          }
          case 16: {
            MaxFuel = input.ReadUInt32();
            break;
          }
          case 24: {
            NeedNextRankExp = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class RankTable : pb::IMessage<RankTable> {
    private static readonly pb::MessageParser<RankTable> _parser = new pb::MessageParser<RankTable>(() => new RankTable());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RankTable> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MokomoGames.Protobuf.RankTableReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RankTable() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RankTable(RankTable other) : this() {
      records_ = other.records_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RankTable Clone() {
      return new RankTable(this);
    }

    /// <summary>Field number for the "records" field.</summary>
    public const int RecordsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::MokomoGames.Protobuf.RankTableRecord> _repeated_records_codec
        = pb::FieldCodec.ForMessage(10, global::MokomoGames.Protobuf.RankTableRecord.Parser);
    private readonly pbc::RepeatedField<global::MokomoGames.Protobuf.RankTableRecord> records_ = new pbc::RepeatedField<global::MokomoGames.Protobuf.RankTableRecord>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::MokomoGames.Protobuf.RankTableRecord> Records {
      get { return records_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RankTable);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RankTable other) {
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
    public void MergeFrom(RankTable other) {
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
