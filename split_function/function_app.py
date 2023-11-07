import azure.functions as func
import datetime
import json
import logging

app = func.FunctionApp()


@app.route(route="split_function", auth_level=func.AuthLevel.ANONYMOUS, methods=["POST"])
def split_function(req: func.HttpRequest) -> func.HttpResponse:

    data = req.get_json()

    expenses = data['expenses']
    numberOfMembers = data['numberOfMembers']

    sumExp = 0
    userToTotalDict = {}

    # Iterate through the expenses and calculate the sum
    for expense in expenses:
        sumExp += expense['Amount']
        if expense['PaidByUser']['Id'] in userToTotalDict:
            userToTotalDict[expense['PaidByUser']['Id']] += expense['Amount']
        else:
            userToTotalDict[expense['PaidByUser']['Id']] = expense['Amount']

    eachPersonShouldPay = sumExp / numberOfMembers

    respArr = []

    for user_id, total in userToTotalDict.items():
        user = {}
        user['userId'] = user_id
        user['shouldPay'] = eachPersonShouldPay - total
        respArr.append(user)

    response_json = json.dumps(respArr)

    return func.HttpResponse(
        response_json,
        mimetype="application/json",
        status_code=200
    )
