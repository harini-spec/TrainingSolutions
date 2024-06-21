const student_details = {
    name: 'John',
    age: 20,
    Rollno: 101,

    displayStudentDetails() {
        console.log(`Name: ${this.name}, Age: ${this.age}, Rollno: ${this.Rollno}`);
    }
}

const student_gradesheet = {
    marks: [90, 80, 70, 60, 50, 40, 30],
    displayGradeSheet(){
        console.log(`Marks: ${this.marks}`);
    }
}

// 2 ways to set prototype
Object.setPrototypeOf(student_gradesheet, student_details);
// student_gradesheet.__proto__ = student_details;

student_gradesheet.displayStudentDetails();
student_gradesheet.displayGradeSheet();

