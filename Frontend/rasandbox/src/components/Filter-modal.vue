<template>
  <div class="modal">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="box">
        <h1>Filters</h1>
        <div class="columns">
          <div class="column is-one-fourth">
            <input
              class="input"
              type="text"
              placeholder="Hersteller"
              v-model="company"
              @input="$emit('companyChange', company)"
            />
          </div>
          <div class="column is-one-fourth">
            <div class="select">
              <select
                name="Genre"
                v-model="genre"
                @change="$emit('genreChange', genre)"
              >
                <option value="Horror">Horror</option>
                <option value="Abenteuer">Abenteuer</option>
                <option value="Physik">Physik</option>
                <option value="Survival">Survival</option>
                <option value="Simulation">Simulation</option>
                <option value="Aufbauspiel">Aufbauspiel</option>
                <option value="Robert hat Spaß">Robert hat Spaß</option>
                <option value="RPG">RPG</option>
                <option value="MMO">MMO</option>
                <option value="Krieg">Krieg</option>
                <option value="Weltraum">Weltraum</option>
                <option value="Story">Story</option>
                <option value="Cyberpunk">Cyberpunk</option>
                <option value="FPS">FPS</option>
              </select>
            </div>
          </div>
          <div class="column is-one-fourth">
            <span>Minimum Preis</span>
            <input
              type="range"
              name="minPrice"
              min="0"
              max="20"
              step="1"
              v-model="minPrice"
              @change="$emit('minPriceChange', minPrice)"
            />
            {{ minPrice }} €
            <span>Maximal Preis</span>
            <input
              type="range"
              name="minPrice"
              min="30"
              max="100"
              step="1"
              v-model="maxPrice"
              @change="$emit('maxPriceChange', maxPrice)"
            />
            {{ maxPrice }} €
          </div>
          <div class="column is-one-fourth">
            <label for="start">Release date:</label>
            <input
              type="date"
              id="start"
              name="trip-start"
              value="2023-06-12"
              min="1999-01-01"
              max="2100-12-31"
              v-model="releaseDate"
              @change="$emit('releaseDateChange', releaseDate)"
            />
          </div>
        </div>
      </div>
    </div>
    <button
      class="modal-close is-large"
      aria-label="close"
      @click="$emit('close')"
    >
      close
    </button>
  </div>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  name: "FilterModal",
  components: {},
  data() {
    return {
      showDropDown: false,
      company: "",
      genre: "",
      minPrice: 0,
      maxPrice: 0,
      releaseDate: "",
    };
  },
  methods: {},
});
</script>
