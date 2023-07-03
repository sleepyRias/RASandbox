<template>
  <div :class="{ 'is-darkmode': darkmode }">
    <user-modal
      v-if="showModal"
      :class="{ 'is-active': showModal }"
      :favGameList="favGameList"
      @close="showModal = false"
      @updateColorScheme="toggleDarkmode"
    />
    <filter-modal
      v-if="showFilter"
      :class="{ 'is-active': showFilter }"
      @close="showFilter = false"
      @submit="updateFilter"
    />
    <div class="main-header">
      <h1 class="main-title">Sandbox Project</h1>
      <button @click="showModal = true" class="button is-link">User</button>
    </div>
    <div class="columns">
      <div class="column">
        <input type="text" class="input is-normal" v-model="inputText" />
      </div>
      <div class="column">
        <button @click="submitGame(inputText)" class="button is-success">
          Submit
        </button>
      </div>
      <div class="column">
        <button class="button is-warning" @click="showFilter = !showFilter">
          Filter
        </button>
      </div>
      <div class="colum">
        <button class="button" @click="getGames(amount)">G A M E S</button>
        <input class="input" v-model="amount" />
      </div>
    </div>
    <div class="columns is-gapless is-multiline">
      <div
        class="column is-one-third"
        v-for="game in gamesList"
        :key="game.name"
      >
        <div
          class="gameBox"
          v-if="
            (filter.company === undefined || filter.company === game.company) &&
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
          <button
            class="button is-warning favButton"
            @click="addGameToFavorites(game)"
          >
            Favorite
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
const repo = new SteamRepositoryAxios(axios);
import Vue from "vue";
import axios from "axios";
import { Game } from "./Game";
import { SteamRepositoryAxios } from "./SteamRepositoryAxios";
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
      amount: 0,
      favGameList: [] as Game[],
      darkmode: false,
    };
  },
  methods: {
    requestGames() {
      this.gamesList = repo.loadGames();
    },
    submitGame(name: string) {
      this.gamesList.push({ name: name, id: 0, price: 0, genre: 0 });
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
    async getGames(amount: number) {
      this.gamesList = await repo.getGames(amount);
    },
    addGameToFavorites(game: Game) {
      this.favGameList.push(game);
    },
    toggleDarkmode(mode: boolean) {
      this.darkmode = mode;
    },
  },
  beforeMount() {
    this.requestGames();
  },
});
</script>

<style>
.main-header {
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
  margin: 5px 5px 60px 5px;
}
.main-title {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  font-size: larger;
  font-weight: 600;
}
.gameBox {
  border: 1px solid black;
  margin: 10px 5px 0px 5px;
  display: flex;
  justify-content: center;
  align-items: center;
  border-radius: 20px;
}
.favButton {
  margin-left: 20px;
}
.is-darkmode {
  background-color: black;
  color: white;
}
</style>
