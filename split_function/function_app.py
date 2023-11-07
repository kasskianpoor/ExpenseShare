import azure.functions as func
import datetime
import json
import logging

app = func.FunctionApp()


@app.route(route="split_function", auth_level=func.AuthLevel.ANONYMOUS, methods=["POST"])
def split_function(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('HEREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE')

    data = req.get_json()

    expenses = data['expenses']
    logging.info(expenses)

    sumExp = 0

    # Iterate through the expenses and calculate the sum
    for expense in expenses:
        sumExp += expense['Amount']

    logging.info(sumExp)

    json_array = [
        {"key1": "value1", "key2": "value2"},
        {"key1": "value3", "key2": "value4"}
    ]

    response_json = json.dumps(json_array)

    return func.HttpResponse(
        response_json,
        mimetype="application/json",
        status_code=200
    )
