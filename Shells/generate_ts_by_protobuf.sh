#!bin/sh

PROTOC_GEN_TS_PATH="./node_modules/.bin/protoc-gen-ts"
OUT_DIR="./"

protoc \
    --plugin="protoc-gen-ts.cmd=${PROTOC_GEN_TS_PATH}" \
    --js_out="import_style=commonjs,binary:${OUT_DIR}" \
    --ts_out="${OUT_DIR}" \
    ./protos/UserData.proto

if [ ! -d "./protos/src" ];then
    mkdir ./protos/src
fi

mv ./protos/*.js ./protos/src
mv ./protos/*.d.ts ./protos/src


