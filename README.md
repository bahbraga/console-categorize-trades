#  Categorize trades in a bank�s portfolio
# Using Visual Studio 2022 .NET CORE 6.0

Currently, there are three categories (in order of precedence):
1. EXPIRED: Trades whose next payment date is late by more than 30 days based on a reference date which will 
be given.
2. HIGHRISK: Trades with value greater than 1,000,000 and client from Private Sector.
3. MEDIUMRISK: Trades with value greater than 1,000,000 and client from Public Sector.

Question 2: A new category was created called PEP (politically exposed person). Also, a new bool property 
IsPoliticallyExposed was created in the ITrade interface. A trade shall be categorized as PEP if 
IsPoliticallyExposed is true. Describe in at most 1 paragraph what you must do in your design to account for this 
new category

R: 

