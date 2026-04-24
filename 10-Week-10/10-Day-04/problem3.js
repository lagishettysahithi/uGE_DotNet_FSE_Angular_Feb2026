"use strict";
class Employee {
    id;
    name;
    salary;
    constructor(id, name, salary) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }
    //  Getter for salary
    getSalary() {
        return this.salary;
    }
    //  Setter for salary with validation
    setSalary(value) {
        if (value > 0) {
            this.salary = value;
        }
        else {
            console.log("Salary must be greater than 0");
        }
    }
    //  Method to display details
    displayDetails() {
        console.log(`Employee ID: ${this.id}`);
        console.log(`Name: ${this.name}`);
        console.log(`Salary: ${this.salary}`);
    }
}
// Derived Class: Manager
class Manager extends Employee {
    teamSize;
    // Constructor using super
    constructor(id, name, salary, teamSize) {
        super(id, name, salary);
        this.teamSize = teamSize;
    }
    //  Method Overriding
    displayDetails() {
        // Access protected property 'name'
        console.log(`Manager ID: ${this.id}`);
        console.log(`Name: ${this.name}`);
        console.log(`Team Size: ${this.teamSize}`);
        console.log(`Salary: ${this.getSalary()}`);
    }
}
const emp1 = new Employee(1, "Sahithi", 30000);
const mgr1 = new Manager(2, "Susmitha", 60000, 5);
// Calling methods
console.log("---- Employee Details ----");
emp1.displayDetails();
// Update salary using setter
emp1.setSalary(35000);
console.log("Updated Salary:", emp1.getSalary());
console.log("\n---- Manager Details ----");
mgr1.displayDetails();
