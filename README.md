# search-app-demo
.net core 3.1 sever api + simple angular client app


Test task for 3 hrs

Please create a web application with the following structure:
- [x] Server Side  - Web API (REST)
- [x] Client Side – SPA (Angular/React/Vue) 

The frontend application should consist of one page with a search box (text box + button).
The user will enter a search phrase. The application will search the phrase in Google and Bing sites (not API) and will extract 5 top results from each site and will store the titles of the results in MS SQL database and present on in the page under the search box.

There should be one table in DB, with the following columns:
- [x] SearchEngine  - Bing/Google
- [x] Request – search phrase used
- [x] Title – result title
- [x] EnteredDate – date and time of the request


The search in Bing and Google should be done in parallel.
Feel free to use any NuGet package in your task.

Result package should consist of:
- [x] Backend solution
- [x] Frontend project
- [x] DB backup

Good luck!
