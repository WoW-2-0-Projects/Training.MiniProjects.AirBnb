<template>

    <div class="flex gap-6 md:gap-12 overflow-x-scroll no-scrollbar">

        <listing-category-card v-for="location in 20"/>

    </div>

</template>
<script setup lang="ts">
import ListingCategoryCard from "@/modules/locations/components/ListingCategoryCard.vue";
</script>