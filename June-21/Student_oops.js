// Encapsulation
class Student{
    constructor(name, age, rollno){
        this.name = name;
        this.age = age;
        this.rollno = rollno;
    }

    DisplayDetails(){
        console.log(`Name: ${this.name}, Age: ${this.age}, Roll No: ${this.rollno}`);
    }
}

// Inheritance, Polymorphism - Method overriding
class StudentGradeSheet extends Student{
    constructor(name, age, rollno, marks){
        super(name, age, rollno);
        this.marks = marks;
    }

    // Abstraction
    calculateGrade(mark){
        if(mark >= 90){
            return "A+";
        }else if(mark >= 80){
            return "A";
        }else if(mark >= 70){
            return "B+";
        }else if(mark >= 60){
            return "B";
        }else if(mark >= 50){
            return "C";
        }else if(mark >= 40){
            return "D";
        }else{
            return "F";
        }
    }

    DisplayDetails(){
        super.DisplayDetails();
        console.log(`Marks: ${this.marks}`);
    }
}

// Inheritance, Polymorphism - Method overriding
class DisplayGradeSheet extends StudentGradeSheet{

    constructor(name, age, rollno, marks){
        super(name, age, rollno, marks);
        this.grades = [];
    }

    getGrades(){
        this.marks.forEach(element => {
            this.grades.push(this.calculateGrade(element));
        });
        return this.grades;
    }

    DisplayDetails(){
        this.getGrades();
        super.DisplayDetails();
        console.log(`Grades: ${this.grades}`);
    }
}

let studentGradeSheet = new DisplayGradeSheet("John", 20, 101, [90, 80, 70, 60, 50, 40, 30]);
studentGradeSheet.DisplayDetails();