import axios from 'axios';

//name of the axios instance (in this case it is 'http')
const http = axios.create({
  baseURL: "https://pokeapi.co/api/v2/pokemon"
});

export default {

    getPokemon(name) {
        return http.get('/' + name);
    }


}