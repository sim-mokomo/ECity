import "google-apps-script"

function createJson(tableName:string) : string{
    var rankTableSheet = SpreadsheetApp.getActiveSpreadsheet().getSheetByName(tableName)
    var rows = rankTableSheet.getDataRange().getValues()
    var header = rows.splice(0,1)[0]
    var types = rows.splice(0,1)[0]
    
    var table = {}
    var records = rows.map( (row) => {
        var obj = {}
        row.map( (x,index) => {
            obj[header[index]] = x
        })
        return obj
    })
    table[`${tableName}Record`] = records
    var json = JSON.stringify(table)
    return json
}

function createJsonFile(tableName:string,json:string) {
    var folder = getOutputFolder()
    var contentType = "text/json"
    var charset = "utf-8"
    
    var blob = Utilities
    .newBlob("",contentType,tableName)
    .setDataFromString(json,charset)
    
    folder.createFile(blob)
}
