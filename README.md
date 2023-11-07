# ExpenseShare

**Description:**
ExpenseShare simplifies the intricate task of monitoring collective expenditures among you and your companions. When one individual covers an expense, the app facilitates comprehensive record-keeping and adeptly computes each participant's financial obligation.

**How to Run the Application:**

1. **Download and Extract:**
    - Download the zip file.
    - Extract the zip file to a directory of your choice.
2. **Change Directory:**

    - Using a terminal or command line, navigate to the folder where you extracted the zip file.
    - If the name of the folder extracted from the zip file is `ExpenseShare-main`, rename it to `ExpenseShare` and then `cd ExpenseShare`.

3. **Run the Backend Project:**

    - In the first terminal, run the backend project:
        ```shell
        cd APIExpenseShare
        ```
    - Ensure you have .NET SDK installed in your system by running the following command:
        ```shell
        dotnet --info
        ```
    - If you do not have .NET SDK install .NET SDK from [here](https://learn.microsoft.com/en-us/dotnet/core/sdk)
    - After you are sure you have .NET SDK installed run this command:
        ```shell
        dotnet run
        ```

4. **Run the Frontend Project:**

    - In the second terminal, run the frontend project:

        ```shell
        cd ClientExpenseShare
        npm install
        ```

    - If npm install didn't work, make sure you have node installed on your system [here](https://nodejs.org/en).

5. **Check Angular CLI:**

    - Ensure you have Angular CLI installed in your system by running the following command:

        ```shell
        ng version
        ```

    - If Angular CLI is not installed, you can install it from [here](https://angular.io/cli). After installing Angular CLI repeat from step 5.

    - If you have Angular version ^16._._, you are not likely to encounter problems. Try running the following command:
        ```shell
        ng serve
        ```

6. **Run the Azure Function:**
    - In the last terminal, run the Azure function:
        ```shell
        cd split_function
        ```
7. **Check Azure Function Core Tools:**

    - Ensure you have Azure Function Core Tools installed in your system by running the following command:
        ```shell
        func --version
        ```
    - If you do not have the Azure Function Core Tools installed first install it. More information can be found [here](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=linux%2Cisolated-process%2Cnode-v4%2Cpython-v2%2Chttp-trigger%2Ccontainer-apps&pivots=programming-language-python).

    - After you made sure you have the Azure Function Core Tools, run the following command:
        ```shell
        func init
        ```
    - a proped comes up asking you for the worker runtime. The worker runtime is going to be python. Select python.

    - After that, run the command below:
        ```shell
        func start
        ```

These instructions will help you set up and run the ExpenseShare application with ease. Enjoy managing collective expenditures effortlessly!
