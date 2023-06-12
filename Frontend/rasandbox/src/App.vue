<template>
  <div>
    <user-modal
      v-if="showModal"
      :class="{ 'is-active': showModal }"
      @close="showModal = false"
    />
    <h1 class="main-title">Sandbox Project</h1>
    <div class="main-input">
      <input type="text" class="SBinput" v-model="inputText" />
      <button @click="submitGame(inputText)" class="SBbutton">Submit</button>
      <button @click="showModal = true" class="SBbutton">Show Modal</button>
      <dropdown />
    </div>
    <div class="columns is-1-desktop is-multiline">
      <div
        class="column is-one-third gameBox"
        v-for="game in gamesList"
        :key="game.name"
      >
        <ul>
          <li>{{ game.name }}</li>
          <li>{{ game.price }} €</li>
          <li>{{ game.company }}</li>
          <li>{{ game.releaseDate }}</li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Games from "./response.json";
import { Game } from "./Game";
import UserModal from "./components/User-modal.vue";
import Dropdown from "./components/Dropdown-menu.vue";

export default Vue.extend({
  name: "App",
  components: {
    UserModal,
    Dropdown,
  },
  data() {
    return {
      inputText: "",
      gamesList: [] as Game[],
      showModal: false,
      showDropDown: false,
    };
  },
  methods: {
    requestGames() {
      this.gamesList = Games.response.games;
    },
    submitGame(name: string) {
      this.gamesList.push({ name: name, appid: 0 });
    },
  },
  beforeMount() {
    this.requestGames();
  },
});
</script>

<style>
.main-title {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
.SBinput {
  border: none;
  border-radius: 10px;
  background-color: lightgrey;
  padding-left: 5px;
  height: 25px;
}
.SBbutton {
  height: 27px;
  margin-left: 5px;
  border: none;
  border-radius: 10px;
  background-color: lightgrey;
}
.main-input {
  display: flex;
  justify-content: center;
}
.gameBox {
  border: 1px solid black;
  margin: 0 auto;
  margin-top: 10px;
  display: flex;
  justify-content: center;
  align-items: center;
  border-radius: 20px;
}
</style>
