const userName: string = "Sahithi";
let age: number = 2;
const email: string = "sahithi@example.com";
const isSubscribed: boolean = true;

//  Type Inference (no explicit types)
let city = "Hyderabad";     
let points = 100;           

let profileMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}`;

age = age + 1;

let isEligibleForPremium: boolean = (age > 18) && isSubscribed;

let isAdult: boolean = age >= 18;


console.log("User Name    :", userName);
console.log("Age after increment   :", age);
console.log("Email   :", email);
console.log("Subscribed   :", isSubscribed);

console.log("City :", city);
console.log("Points (Inferred)   :", points);

console.log("Profile Message:", profileMessage);

console.log("Is Adult   :", isAdult);
console.log("Eligible for Premium   :", isEligibleForPremium);

export{};  