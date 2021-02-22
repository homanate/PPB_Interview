# PPB_Interview
Hi, my name is Ian Homan and this is my submission for the PP Betfair Associate .NET Engineering role. 

Application reads in data as a txt file from a specified location. From there it breaks data down into
a list of strings, making it more manageable, to allow for structured output reports to be created.

Application sorts data by selection name and currency type, then aggregates it to generate num of bets,
Total Stakes and Total liability for each entry.

Application also outputs a second report showing Total Liability by currency.

This application also allows for both reports to be converted and output as CSV files.

***Some Caveats***
I was hoping to create tests for all logic created, however due to time restrictions this could not be
achieved. I did begin to create some templates for tests (within 'LiabilityReportTests') but ultimately
did not have time to complete them.

I also could not implement source and format of the data, e.g. change from reading a CSV file to requesting
json data over HTTP, as again I ran out of time.

Lastly, formatting of report that is output to console requires tidying up, but again I simply ran out of time
and wanted to focus on outputting the data correctly.

Thank You
Ian
