const words = ["HELLO", "SMART", "SWEET", "HEART", "RESIN", "FORCE", "ALARM", "SWEAR", "SWEAT", "SWEET", "SWEPT", "SWEEP", "SWELL", "SWIFT", "SWINE", "SWING", "SWIPE", "SWIRL", "SWISH", "SWISS", "SWORN", "SWUNG"]
const word = words[Math.floor(Math.random() * words.length)]
var current_row = 0
var current_col = 0
var current_str = ""
var found = false

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
    if(found) return
    if(letter.length == 1){
        if(current_col < 5 && current_row < 6){
            var guess = document.querySelector(`.guess-${current_row}`)
            var cols = guess.querySelectorAll('.col')
            cols[current_col].innerHTML = letter
            cols[current_col].classList.add("active_container")
            current_col++
            current_str += letter 
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
        }
    }
    else{
        if(current_col == 5){
            validateWord()
        }
    }
}

const MarkDivs = (col, classname) => {
    col.classList.add(classname)
    col.classList.remove("active_container")
    col.style.border = "Transparent"
    var elem = document.getElementById(col.innerHTML)
    elem.classList.add(classname)
}

const validateWord = () => {
    if(current_row<=5 && !found){
        var guess = document.querySelector(`.guess-${current_row}`)
        var cols = guess.querySelectorAll('.col')
    
        if(current_str == word)
            {
                for(var i=0;i<5;i++){
                    MarkDivs(cols[i], "correct_pos")
                }
                found = true
            }
        else{
            for(var i=0;i<5;i++){
                if(word.includes(cols[i].innerHTML) && word.indexOf(cols[i].innerHTML) == i)
                {
                    MarkDivs(cols[i], "correct_pos")
                }
                else if(word.includes(cols[i].innerHTML)){
                    MarkDivs(cols[i], "correct_char")
                }
                else{
                    MarkDivs(cols[i], "wrong_char")
                }
            }
        }
        current_col = 0
        current_row += 1
        current_str = ""
    }
}

const guessLetter = (letter) => {
    displayLetter(letter)
}