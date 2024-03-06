# CurrencyTables
Validating currency rates using Selenium

There are two scenarios created for how driver can get to the currency rates table page:  
1 - going through the URL, which is built using the information provided in the dataset (currency abbreviation and date);  
2 - imitating user action by clicking elements in the UI.  
  
"Rates" folder contains some scrapped rates of the most popular currencies for 2023-02-01. A few of the rates are intentionally changed to cause some checks to fail. Done it to make the data sample a bit bigger; "Reports" folder stores mini test reports.  
  
Tests Logic:  
- Currency rates are taken from the file;  
- Obtained rates are compared with the rates on the web;  
- A mini-report is generated according to the results of the comparison.


NOTE: I'm implying that the currency rates table will have the same sequence all the time. It can be improved to search for the desired currency through the whole list.
