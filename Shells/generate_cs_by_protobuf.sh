#!bin/sh

OUT_DIR_TO_UNITY="./Assets/Scripts/IDL"
OUT_DIR_TO_AZURE="./AzureFunctions"

if [[ $# -ne 1 ]]; then
    echo "第一引数に変換するprotoファイルパスを指定してください"
    exit 1
fi

if [[ ! -d OUT_DIR ]];then
    mkdir OUT_DIR
fi

protoc --proto_path "./protos" --csharp_out="${OUT_DIR_TO_UNITY}" $1
protoc --proto_path "./protos" --csharp_out="${OUT_DIR_TO_AZURE}" $1