<template>
  <div :class="{ 'is-darkmode': darkmode }">
    <user-modal
      v-if="showModal"
      :class="{ 'is-active': showModal }"
      :favGameList="favGameList"
      @close="showModal = false"
      @updateColorScheme="changeDarkmode"
    />
    <filter-modal
      v-if="showFilter"
      :class="{ 'is-active': showFilter }"
      @close="showFilter = false"
      @submit="updateFilter"
    />
    <!-- Filter an modal übereben -->
    <!-- modalbert hinzufügen modal auslagern -->
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
            !filter ||
            (filter.company === game.company &&
              filter.releaseDate === game.releaseDate &&
              isInPricerange(game.price))
          "
        >
          <!-- computed list FILTERN nicht EDITIEREN immer filter list benutzt -->
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
          <!-- stern oben rechts font awesome -->
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
      // kann weg
      gamesList: [] as Game[],
      showModal: false,
      showFilter: false,
      filter: null as GameFilter | null,
      amount: 0,
      // kann weg
      favGameList: [] as Game[],
      // kann raus
      darkmode: false,
    };
  },
  methods: {
    requestGames() {
      this.gamesList = repo.loadGames();
    },
    /** @deprecated **/
    submitGame(name: string) {
      this.gamesList.push({ name: name, id: 0, price: 0, genre: 0 });
    },
    // WEG
    updateFilter(filter: GameFilter) {
      this.showFilter = false;
      this.filter = { ...this.filter, ...filter };
      // modal anders ausmachen
    },
    isInPricerange(price: number): boolean {
      if (!this.filter) {
        return true;
      }
      return price >= this.filter.minPrice && price <= this.filter.maxPrice;
    },
    isInGenre(genres: string[]): boolean {
      if (!this.filter) {
        return true;
      }
      return genres.includes(this.filter.genre);
    },
    async getGames(amount: number) {
      this.gamesList = await repo.getGames(amount);
      // amount kommt weg
    },
    addGameToFavorites(game: Game) {
      this.favGameList.push(game);
      // überarbeiten mit user und so
    },
    changeDarkmode(mode: boolean) {
      this.darkmode = mode;
    },
  },
  beforeMount() {
    this.requestGames();
  },
});
</script>

<style lang="scss">
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
  //rober mag flex nicht :(
  border: 1px solid black;
  margin: 10px 5px 0px 5px;
  display: flex;
  justify-content: center;
  align-items: center;
}
.favButton {
  margin-left: 20px;
}
.is-darkmode {
  background-color: black;
  color: white;
}
</style>
