<template>
  <div>
    <h1 class="main-title">Sandbox Project</h1>
    <div class="main-input">
      <input type="text" class="SBinput" v-model="inputText" />
      <button @click="submitGame(inputText)" class="SBbutton">Submit</button>
    </div>
    <div class="gameBox" v-for="game in gamesList" :key="game.name">
      {{ game.name }}
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Games from "@/response.json";

export default Vue.extend({
  name: "App",
  components: {},
  data() {
    return {
      inputText: "",
      gamesList: [],
    };
  },
  methods: {
    requestGames() {
      this.gamesList = Games.response.games;
    },
    submitGame(name) {
      this.gamesList.push({ name: name });
    },
  },
  beforeMount() {
    this.requestGames();
  },
});
</script>

<style>
html {
  background-image: linear-gradient(cyan, hotpink);
}
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
  border: 2px solid black;
  height: 10vh;
  width: 90vw;
  margin: 0 auto;
  margin-top: 10px;
  display: flex;
  justify-content: center;
  align-items: center;
  border-radius: 20px;
}
</style>
