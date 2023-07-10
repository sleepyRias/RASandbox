<template>
  <div class="modal">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="box" :class="themeClass">
        <div class="columns is-multiline">
          <div v-if="name !== ''">
            <div class="column">
              <figure class="image is-128x128">
                <img src="https://bulma.io/images/placeholders/128x128.png" />
              </figure>
            </div>
            <div class="column">
              <span>Username: {{ username }}</span>
            </div>
            <div class="column">
              <span>Name: {{ name }}</span>
            </div>
            <div class="column">
              <ul>
                Favorite Games:
                <li v-for="game in favoriteGamesList" :key="game.name">
                  {{ game.name }}
                </li>
              </ul>
              <select class="column select" v-model="colorScheme">
                {{
                  colorScheme
                }}
                <option :value="'dark-theme'">Darkmode</option>
                <option :value="'light-theme'">Lightmode</option>
              </select>
              <button class="button is-info" @click="setTheme">Save</button>
            </div>
          </div>
          <div v-else-if="name === ''">
            <div class="column">
              <span>Loaduser:</span>
              <input v-model="username" class="input" />
              <button
                class="button is-primary"
                @click="loadUserWithKey(username)"
              >
                Load
              </button>
            </div>
            <div class="column">
              <h1>New User</h1>
              <span>Username: </span>
              <input class="input" v-model="newUser.username" />
              <span>Name: </span>
              <input class="input" v-model="newUser.name" />
              <button class="button is-info" @click="createNewUser">
                Create!
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <button class="modal-close is-large" @click="$emit('close')">close</button>
  </div>
</template>
<script lang="ts">
import Vue from "vue";
import { Game } from "../../shared/interfaces/Game";
import { User } from "../../shared/interfaces/User";

export default Vue.extend({
  name: "UserModal",
  data() {
    return {
      username: "",
      name: "",
      favoriteGamesList: [] as Game[],
      colorScheme: "",
      newUser: {
        name: "",
        username: "",
        favoriteGamesList: [] as Game[],
      } as User,
    };
  },
  methods: {
    createNewUser() {
      this.newUser.favoriteGamesList = this.favGameList;
      const user = {
        name: this.newUser.name,
        username: this.newUser.username,
        favoriteGamesList: this.newUser.favoriteGamesList,
      };
      localStorage.setItem(user.username, JSON.stringify(user));
      this.loadUserWithKey(user.username);
    },
    loadUserWithKey(key: string) {
      var user = {} as User;
      // eslint-disable-next-line @typescript-eslint/ban-ts-comment
      // @ts-ignore
      user = JSON.parse(localStorage.getItem(key));
      this.name = user.name;
      this.username = user.username;
      this.favoriteGamesList = user.favoriteGamesList;
      this.colorScheme = user.colorScheme;
      this.$store.dispatch("setTheme", user.colorScheme);
    },
    toggleTheme() {
      const newTheme =
        this.$store.getters.getTheme === "light-theme"
          ? "dark-theme"
          : "light-theme";
      this.$store.dispatch("setTheme", newTheme);
    },
    setTheme() {
      this.$store.dispatch("setTheme", this.colorScheme);
    },
  },
  props: {
    favGameList: {
      default: [],
      type: [],
    },
  },
  computed: {
    themeClass() {
      return this.$store.getters.getTheme === "light-theme"
        ? "light-theme"
        : "dark-theme";
    },
  },
});
</script>
../../shared/interfaces/Game ../../shared/interfaces/User
