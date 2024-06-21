// Creating a parent object as a prototype - This is an object, not a class/function
// Object can have functions too - functions are like property of object

const parent = {
    name: 'Parent Object',
    greet(){
      console.log("Hello from the parent");
    }
  };
  
// Creating a child object
const child = {
  name: 'Child Object'
};

// Performing prototype inheritance
child.__proto__ = parent;

// Accessing the method from the parent prototype
child.greet(); 

// Output: Hello from the parent 