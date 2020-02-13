// package: ecity
// file: protos/UserData.proto

import * as jspb from "google-protobuf";

export class UpdateStaminaRequest extends jspb.Message {
  getDiff(): number;
  setDiff(value: number): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): UpdateStaminaRequest.AsObject;
  static toObject(includeInstance: boolean, msg: UpdateStaminaRequest): UpdateStaminaRequest.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: UpdateStaminaRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): UpdateStaminaRequest;
  static deserializeBinaryFromReader(message: UpdateStaminaRequest, reader: jspb.BinaryReader): UpdateStaminaRequest;
}

export namespace UpdateStaminaRequest {
  export type AsObject = {
    diff: number,
  }
}

export class UpdateStaminaResponse extends jspb.Message {
  getCurrentstamina(): number;
  setCurrentstamina(value: number): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): UpdateStaminaResponse.AsObject;
  static toObject(includeInstance: boolean, msg: UpdateStaminaResponse): UpdateStaminaResponse.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: UpdateStaminaResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): UpdateStaminaResponse;
  static deserializeBinaryFromReader(message: UpdateStaminaResponse, reader: jspb.BinaryReader): UpdateStaminaResponse;
}

export namespace UpdateStaminaResponse {
  export type AsObject = {
    currentstamina: number,
  }
}

export class PlayerSaveData extends jspb.Message {
  getStamina(): number;
  setStamina(value: number): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): PlayerSaveData.AsObject;
  static toObject(includeInstance: boolean, msg: PlayerSaveData): PlayerSaveData.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: PlayerSaveData, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): PlayerSaveData;
  static deserializeBinaryFromReader(message: PlayerSaveData, reader: jspb.BinaryReader): PlayerSaveData;
}

export namespace PlayerSaveData {
  export type AsObject = {
    stamina: number,
  }
}

export class GetPlayerSaveDataResponse extends jspb.Message {
  hasSavedata(): boolean;
  clearSavedata(): void;
  getSavedata(): PlayerSaveData | undefined;
  setSavedata(value?: PlayerSaveData): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): GetPlayerSaveDataResponse.AsObject;
  static toObject(includeInstance: boolean, msg: GetPlayerSaveDataResponse): GetPlayerSaveDataResponse.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: GetPlayerSaveDataResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): GetPlayerSaveDataResponse;
  static deserializeBinaryFromReader(message: GetPlayerSaveDataResponse, reader: jspb.BinaryReader): GetPlayerSaveDataResponse;
}

export namespace GetPlayerSaveDataResponse {
  export type AsObject = {
    savedata?: PlayerSaveData.AsObject,
  }
}

