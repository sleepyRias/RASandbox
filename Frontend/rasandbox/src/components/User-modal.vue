<template>
  <div class="modal">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="box">
        <div class="columns">
          <div v-if="name !== ''">
            <div class="column">
              <figure class="image is-128x128">
                <img src="https://bulma.io/images/placeholders/128x128.png" />
              </figure>
            </div>
            <div class="column is-multiline">
              <span>Username: {{ username }}</span>
              <button class="button" @click="changeUsername = true">
                Change Username
              </button>
              <input v-if="changeUsername" v-model="username" class="input" />
              <button
                v-if="changeUsername"
                @click="storeChanges"
                class="button is-success"
              >
                Submit
              </button>
            </div>
            <div class="column">
              <span>Name: {{ name }}</span>
              <button @click="changeName = true" class="button">
                Change Name
              </button>
              <input v-if="changeName" v-model="name" class="input" />
              <button
                v-if="changeName"
                @click="storeChanges"
                class="button is-success"
              >
                Submit
              </button>
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
          </div>
        </div>
      </div>
    </div>
    <button class="modal-close is-large" @click="$emit('close')">close</button>
  </div>
</template>
<script lang="ts">
import Vue from "vue";
import { User } from "../User";

export default Vue.extend({
  name: "UserModal",
  data() {
    return {
      changeUsername: false,
      changeName: false,
      username: "",
      name: "",
    };
  },
  methods: {
    storeChanges() {
      const user = {
        name: this.name,
      };
      localStorage.setItem(this.username, JSON.stringify(user));
    },
    loadUserWithKey(key: string) {
      var user = {} as User;
      user = JSON.parse(localStorage.getItem(key));
      this.name = user.name;
    },
  },
});
</script>
