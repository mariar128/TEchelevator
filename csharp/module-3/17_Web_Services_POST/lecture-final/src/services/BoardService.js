import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:3000"
});

export default {

  //these are about boards

  getBoards() {
    return http.get('/boards');
  },

  addBoard(newBoard) {
    return http.post('/boards', newBoard);
  },

  deleteBoard(boardID) {
    return http.delete(`/boards/${boardID}`);
  },


  //these are about cards 

  getCards(boardID) {
    return http.get(`/boards/${boardID}`)
  },

  getCard(cardID) {
    return http.get(`/cards/${cardID}`)
  },

  addCard(card) {
    return http.post('/cards', card);
  },

  updateCard(card) {
    return http.put(`/cards/${card.id}`, card);
  },

  deleteCard(cardID) {
    return http.delete(`/cards/${cardID}`);
  }

}
