const words = ["HELLO", "SMART", "SWEET", "HEART", "RESIN", "FORCE", "ALARM", "SWEAR", "SWEAT", "SWEET", "SWEPT", "SWEEP", "SWELL", "SWIFT", "SWINE", "SWING", "SWIPE", "SWIRL", "SWISH", "SWISS", "SWORN", "SWUNG"]
const word = words[Math.floor(Math.random() * words.length)]
var current_row = 0
var current_col = 0
var current_str = ""
console.log(word)

const loadGuessContainer = () => {
    var guess_container = document.querySelector('.guess_container')
    container_text = ""
    for(var i=0;i<6;i++){
        container_text += `<div class='guess-${i}'>
                            <div class="row">
                                <div class="col">
                                </div>
                                <div class="col">
                                </div>
                                <div class="col">
                                </div>
                                <div class="col">
                                </div>
                                <div class="col">
                                </div>
                            </div>
                        </div>`
    }
    var guesses = document.createElement('div')
    guesses.innerHTML = container_text
    guess_container.appendChild(guesses)
}

const displayLetter = (letter) => {
    if(letter.length == 1){
        if(current_col < 5){
            var guess = document.querySelector(`.guess-${current_row}`)
            var cols = guess.querySelectorAll('.col')
            cols[current_col].innerHTML = letter
            cols[current_col].classList.add("active_container")
            current_col++
            current_str += letter 
            console.log(current_str)
        }
    }
    else if(letter=="Del"){
        if(current_col > 0){
            current_col--
            var guess = document.querySelector(`.guess-${current_row}`)
            var cols = guess.querySelectorAll('.col')
            cols[current_col].innerHTML = ""
            cols[current_col].classList.remove("active_container")
            current_str = current_str.slice(0, -1)
            console.log(current_str)
        }
    }
    else{
        if(current_col == 5){
            validateWord()
        }
    }
}

const validateWord = () => {
    if(current_str == word)
        var guess = document.querySelector(`.guess-${current_row}`)
        var cols = guess.querySelectorAll('.col')
        for(var i=0;i<5;i++){
            cols[i].classList.add("correct_pos")
            cols[i].classList.remove("active_container")
            cols[i].style.border = "Transparent"
            var elem = document.getElementById(cols[i].innerHTML )
            elem.classList.add("correct_pos")
        }
}

const guessLetter = (letter) => {
    displayLetter(letter)
    // var guess = document.querySelector(`.guess-${current_row}`)
    // var cols = guess.querySelectorAll('.col')
    // cols[current_col].innerHTML = letter
    // current_col++
    // if(current_col == 5){
    //     current_row++
    //     current_col = 0
    // }
}