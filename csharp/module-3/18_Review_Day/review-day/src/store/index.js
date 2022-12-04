import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    todos: [
      { title: 'Hello World', 
        description: 'I like cats'
      }
    ]
  },
  mutations: {
    ADD_TODO(state, todo) {
      state.todos.push = todo;
    }
  },
  actions: {
  },
  modules: {
  }
})