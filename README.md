# Fangame-Manager
A tool for unpacking Guy fangames, remembering new ones, helper tools and push into google spreadsheet.
Screenshots and list of features at: http://iwannacommunity.com/forum/index.php?topic=2227.0

Open the Nuget package manager in Visual Studio and it will give an option to restore needed packages.
Feel free to add pull requests. A major work needing to be done is convertion into WPF from winforms.


-------Help for setting up google script------<br>
To compile and have the google integration work, you have to get a google developers client id, secret key and script id.
To get the client id and secret key, enable developer API.<br>
1) console.developers.google.com make the default project<br>
2) Enable Google Apps Script Execution API<br>
3) Create Oauth client ID and choose other<br>
4) Save the client ID and secret key<br>
5) Create Apps Script at script.google.com<br>
6) Save a new version of the script<br>
7) Publish as API Executable<br>
8) Save the script ID<br>
9) Connect the Script to Project at Resources - Developers Console Project<br>
10) Add the IDs and secret to c# project<br>
