<template>
  <div>
    <user-modal
      v-if="showModal"
      :class="{ 'is-active': showModal }"
      @close="showModal = false"
    />
    <filter-modal
      v-if="showFilter"
      :class="{ 'is-active': showFilter }"
      @close="showFilter = false"
      @companyChange="handelFilterChange"
      @genreChange="handelFilterChange"
      @minPriceChange="handelFilterChange"
      @maxPriceChange="handelFilterChange"
      @releaseDateChange="handelFilterChange"
    />
    <h1 class="main-title">Sandbox Project</h1>
    <div class="columns">
      <div class="colum is-one-fourth">
        <input type="text" class="input is-normal" v-model="inputText" />
      </div>
      <div class="colum is-one-fourth">
        <button @click="submitGame(inputText)" class="button">Submit</button>
      </div>
      <div class="colum is-one-fourth">
        <button @click="showModal = true" class="button">Show Modal</button>
      </div>
      <div class="colum is-one-fourth">
        <button class="button" @click="showFilter = !showFilter">Filter</button>
      </div>
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
import FilterModal from "./components/Filter-modal.vue";
export default Vue.extend({
  name: "App",
  components: {
    UserModal,
    FilterModal,
  },
  data() {
    return {
      inputText: "",
      gamesList: [] as Game[],
      showModal: false,
      showFilter: false,
    };
  },
  methods: {
    requestGames() {
      this.gamesList = Games.response.games;
    },
    submitGame(name: string) {
      this.gamesList.push({ name: name, appid: 0 });
    },
    handelFilterChange(filter: string) {
      return;
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
  margin-bottom: 1rem;
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
  margin-bottom: 0.75rem;
  margin-left: 0.5rem;
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
