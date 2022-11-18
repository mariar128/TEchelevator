// grab the blue button
const blueBtn = document.getElementById('blueBtn');

// we want to clear out the text area when we click the blue button
blueBtn.addEventListener('click', function() {
const txtArea = document.getElementById('txtArea');
txtArea.value = "";
});

// red button time
const redBtn = document.getElementById('redBtn')
redBtn.addEventListener('click',
                        function(event) {
                            const txtArea = document.getElementById('txtArea');
                            txtArea.value = `The red button's event type was:
                            ${event.type} and it happened at: ${event.timeStamp}`;
                        });

// green button.. turn the textbox green
//make the css
const greenBtn = document.getElementById('greenBtn');

greenBtn.addEventListener('click', () => {
    const txtArea = document.getElementById('txtArea');
    txtArea.classList.toggle('greenBackground');
    txtArea.value = "The green button was clicked!";
    const title = document.querySelector('h1');
    title.innerText = "Website With A Green Button";
});

//get the text input
const txtInput = document.getElementById('txtInput');
txtInput.addEventListener('keyup', () => {});
