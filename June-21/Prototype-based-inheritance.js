// Creating a parent object as a prototype
const parent = {
    greet() {
      console.log(`Hello from the parent`);
    }
  };
  
  // Creating a child object
  const child = {
    name: 'Child Object'
  };
  
  // Performing prototype inheritance
  child.__proto__ = parent;
  
  // Accessing the method from the parent prototype
  child.greet(); // Outputs: Hello from the parent 