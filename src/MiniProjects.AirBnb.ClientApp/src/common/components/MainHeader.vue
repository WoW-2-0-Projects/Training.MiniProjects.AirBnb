<template>

    <div
        class="theme-bg fixed h-20 top-0 z-10 content-padding w-full flex justify-between items-center border-b border-borderSecondary text-textPrimary">

        <!-- Logo -->
        <main-logo/>

        <!-- Locations menu -->
        <locations-menu/>

        <!-- Profile menu -->
        <profile-menu/>

        <!-- Locations filter -->
        <locations-filter/>

        <!-- Bottom border -->
        <div class="absolute border-b-2 border-borderSecondary"></div>

    </div>

</template>

<script setup lang="ts">

import MainLogo from "@/common/components/icons/MainLogo.vue";
import LocationsMenu from "@/modules/locations/components/LocationsMenu.vue";
import { AppThemeService } from "@/infrastructure/service/AppThemeService";
import ProfileMenu from "@/modules/identity/ProfileMenu.vue";
import LocationsFilter from "@/modules/locations/components/LocationsFilter.vue";


</script>

