//requied parameter
function getWelcomeMessage(name: string): string {
    return `Welcome, ${name}`;
}

// idhi Optional Parameter
function getUserInfo(name: string, age?: number): string {
    if (age !== undefined) {
        return `User ${name} is ${age} years old.`;
    } else {
        return `User ${name} has not provided age.`;
    }
}

// idhi Default Parameter
function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string {
    if (isSubscribed) {
        return `${name} is subscribed to premium services.`;
    } else {
        return `${name} is not subscribed.`;
    }
}

//  Boolean Return Type
function isEligibleForPremium(age: number): boolean {
    return age > 18;
}

// Arrow Function 
const getAccountUpdate = (name: string, status: string): string => {
    return `Hello ${name}, your account status is: ${status}`;
};

const notificationService = {
    appName: "MyAngularApp",

    sendNotification: (userName: string): string => {
        return `Hello ${userName}, welcome to ${notificationService.appName}!`;
    }
};
console.log("-----------------------------");

console.log(getWelcomeMessage("Sai"));
console.log("-----------------------------");
console.log(getUserInfo("Sai", 29));
console.log(getUserInfo("Sahithi"));
console.log("-----------------------------");
console.log(getSubscriptionStatus("Sai", true));
console.log(getSubscriptionStatus("Sahithi")); // default false
console.log("-----------------------------");
console.log("Eligible for Premium  :", isEligibleForPremium(20));

console.log(getAccountUpdate("Sai", "Active"));

console.log(notificationService.sendNotification("Sahithi"));