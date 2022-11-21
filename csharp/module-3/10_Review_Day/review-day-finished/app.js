//grab the blue button 
const blueBtn = document.getElementById('blueBtn');

//we want to clear out the text area when we click the blue button 
blueBtn.addEventListener('click', function() {
    const txtArea = document.getElementById('txtArea');
    txtArea.value = "";
});

//red button time 
const redBtn = document.getElementById('redBtn'); 

redBtn.addEventListener('click', 
                        function(event) {
                            const txtArea = document.getElementById('txtArea');
                            txtArea.value = `The red button's event type was: ${event.type} and it happened at: ${event.timeStamp}`;
                        });


//green button ... turn the textbox green
//make a CSS class to do a green background -> .greenBackground

const greenBtn = document.getElementById('greenBtn');

greenBtn.addEventListener('click', () => {
    const txtArea = document.getElementById('txtArea');
    //in addition to add and remove, toggle will turn a CSS class on/off
    txtArea.classList.toggle('greenBackground');
    txtArea.value = "The green button was clicked!"; 
    const title = document.querySelector('h1'); 
    title.innerText = "Website With A Green Button"; 
});

//get the text input
const txtInput = document.getElementById('txtInput'); 
txtInput.addEventListener('keyup', (event) => {
    const para = document.getElementById('borderedPara');
    //I want to know if the key that came up is the enter key
    if(event.key === 'Enter') {
        //put the value of the text input in the paragraph tag
        para.innerText = txtInput.value;
    }
    if(event.key === '`'){
        displaySecretMessage(para);
    }
});

//a separate function that we will call from an event handler
function displaySecretMessage(element) { 
    element.innerText = "Squirrel cigar party @ 7pm in the parking lot"
}

//REVIEW DAY 

// Given a string, return true if the first 2 chars in the string also appear 
// at the end of the string, such as with "edited".
// frontAgain("edited") → true
// frontAgain("edit") → false
// frontAgain("ed") → true

function frontAgain(word) {
    //.substring() takes characters between two indices
    let firstTwoCharacters = word.substring(0,2); 
    let lastTwoCharacters = word.substr(word.length - 2, 2);
    //compare the variables
    return word.endsWith(firstTwoCharacters);
    //return firstTwoCharacters === lastTwoCharacters;

}