<template>
  <div class="select">
    <select v-model="filter" @change="handleFilterClick">
      <option>Select dropdown</option>
      <option>With options</option>
    </select>
  </div>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  name: "DropDown",
  components: {},
  data() {
    return {
      showDropDown: false,
      filter: "",
    };
  },
  methods: {
    handleFilterClick() {
      console.log(this.filter);
    },
  },
});
</script>
