# ExpenseShare

Description:
This application simplifies the intricate task of monitoring collective expenditures among you and your companions. When one individual covers an expense, the app facilitates comprehensive record-keeping and adeptly computes each participant's financial obligation.

How to run it?

You can download the zip file.
Then extract the zip file somewhere.
Using terminal or commandline cd to the the folder where you extracted the zip file.
If the name of the folder that was extracted from the zip file is ExpenseShare-main change it to ExpenseShare.

Then run this command:
cd ExpenseShare

Now from here you might need three terminals. Because you want to run three projects: the back-end project, the front-end project and the azure function.

In the first terminal to run the back-end project run:
cd APIExpenseShare && dotnet run

In the second terminal to run the front-end project run:
cd ClientExpenseShare

Then run below command:
npm install

Then to run make sure you have angular cli installed in your system run the command below.
ng version

If you weren't successful to run previous comman make sure you install Angular CLI: https://angular.io/cli

If you have Angular version ^16._._ chances are you are not going to run into problem.
Try running the command:
ng serve

In the last terminal to run the azure function run:
cd split_function

To make sure
