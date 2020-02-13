#!bin/sh

OUT_DIR="./Assets/Scripts/IDL"

if [[ $# -ne 1 ]]; then
    echo "第一引数に変換するprotoファイルパスを指定してください"
    exit 1
fi

if [[ ! -d OUT_DIR ]];then
    mkdir OUT_DIR
fi

protoc --csharp_out="${OUT_DIR}" $1

