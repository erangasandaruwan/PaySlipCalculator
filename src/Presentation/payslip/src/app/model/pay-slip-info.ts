export class PaySlipInformation {
  constructor(
    firstName?: string,
    lastName?: string,
    annualSalary?: number,
    superRate?: number,
    payPeriod?: string){ 
      
      if (!firstName){ throw new Error("First name cannot be null or empty."); }  
      if (!lastName){ throw new Error("Last name cannot be null or empty."); }  
      if (annualSalary == null){ throw new Error("Annual salary cannot be null."); }  
      if (annualSalary <= 0.00){ throw new Error("Annual salary cannot be less than or equal to zero."); } 
      if (superRate == null){ throw new Error("Super cannot be null or empty."); }  
      if (superRate <= 0.00 || superRate > 50.00){ throw new Error("Super cannot be less than or equal to zero and greater than 50."); }  
      if (!payPeriod){ throw new Error("Pay period cannot be null or empty."); }   
      
      this.annualSalary = annualSalary;
      this.firstName = firstName;
      this.lastName = lastName;
      this.payPeriod = payPeriod;
      this.superRate = superRate;
  }

  firstName?: string = "";
  lastName?: string = "";
  annualSalary?: number = 0.00;
  superRate?: number = 0.00;
  payPeriod?: string = "";
}

