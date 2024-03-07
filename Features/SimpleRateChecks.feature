# Legend of variables:
# currency - abbreviation of desired currency in capital letters (e.g. EUR, USD, GBP, AUD, CAD);
# date format yyyy-mm-dd (e.g. 2024-01-01);
# tabItem - 1 - 'tools', 2 - 'resources', 3 - 'sign in' or 4 - 'register';
# dropDownItem - possible items after hovering over specific tab item (e.g. Tools: 1 - currency charts, 2 - rate alerts, 3 - historical currency rates, 4 - IBAN calculator, 5 - apps, 6 - more tools)

Feature: SimpleRateChecks

Scenario Outline: Currency rate checks through URL
	Given user checks "<currency>" rates for "<date>"
	When historical rates page for correct "<currency>" is loaded
	Then rates are displayed for "<currency>" on "<date>"

Examples: 
| currency | date       |
| EUR      | 2023-02-01 |
| USD      | 2023-02-01 |
| GBP      | 2023-02-01 |
| CAD      | 2023-02-01 |
| AUD      | 2023-02-01 |

Scenario Outline: Currency rate checks through navigation
	Given user is on main page
	And user hovers over "<tabItem>" tab and clicks "<dropDownItem>" button
	And user clicks on currency
	And user selects "<currency>"
	And user sets date to "<date>"
	When user presses enter in date text field
	Then rates are displayed for "<currency>" on "<date>"

Examples: 
| tabItem | dropDownItem | currency | date       |
| 1       | 3            | EUR      | 2023-02-01 |
| 1       | 3            | USD      | 2023-02-01 |
| 1       | 3            | GBP      | 2023-02-01 |
| 1       | 3            | AUD      | 2023-02-01 |
| 1       | 3            | CAD      | 2023-02-01 |