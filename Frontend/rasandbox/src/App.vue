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
      @submit="updateFilter"
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
    <div class="columns is-gapless is-1-desktop is-multiline">
      <div
        class="column is-one-third"
        v-for="game in gamesList"
        :key="game.name"
      >
        <div
          class="gameBox"
          v-if="
            (filter.company === undefined || filter.company === game.company) &&
            (filter.genre === undefined || isInGenre(game.genre)) &&
            (filter.releaseDate === undefined ||
              filter.releaseDate === game.releaseDate) &&
            ((filter.minPrice === undefined && filter.maxPrice === undefined) ||
              isInPricerange(game.price))
          "
        >
          <ul>
            <li>{{ game.name }}</li>
            <li>{{ game.price }}€</li>
            <li>{{ game.company }}</li>
            <li>{{ game.releaseDate }}</li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
const axios = new AxiosInstance();
const repo = new SteamRepositoryAxios(axios);
import Vue from "vue";
import { AxiosInstance } from "axios";
import { Game } from "./Game";
import { SteamRepositoryAxios } from "@/SteamRepositoryAxios";
import UserModal from "./components/User-modal.vue";
import FilterModal from "./components/Filter-modal.vue";
import { GameFilter } from "./filters";
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
      filter: {} as GameFilter,
    };
  },
  methods: {
    requestGames() {
      repo.loadGames();
    },
    submitGame(name: string) {
      this.gamesList.push({ name: name, appid: 0, price: 0, genre: [] });
    },
    updateFilter(filter: GameFilter) {
      this.showFilter = false;
      Object.assign(this.filter, filter);
    },
    isInPricerange(price: number) {
      return price >= this.filter.minPrice && price <= this.filter.maxPrice;
    },
    isInGenre(genres: string[]) {
      return genres.includes(this.filter.genre);
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
