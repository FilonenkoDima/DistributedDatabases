insert into TypicalBranch.dbo.[Salary documentation details] (EmploymentContractID, PaymentDate, Salary)
Select EmploymentContractID + 1, PaymentDate, Salary from MainOffice.dbo.[Salary documentation details]