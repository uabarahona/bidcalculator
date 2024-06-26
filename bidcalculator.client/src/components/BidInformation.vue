<template>
    <div class="max-w-screen-sm">
        <h2 class="mb-2 text-4xl tracking-tight font-extrabold text-gray-900 ">Calculate total cost</h2>
        <p class="mb-8 font-light text-gray-500 text-xl">Get the total car cost based on a bid</p>
    </div>
    <RadioGroup v-model="bidRequest.carType">
        <RadioGroupLabel class="block text-sm font-medium leading-6 text-gray-900 mb-4">Car Type</RadioGroupLabel>
        <div class="space-x-2 grid grid-cols-2">
            <RadioGroupOption as="template" v-for="cartype in [CarType.Common, CarType.Luxury]" :key="cartype" :value="cartype"
                v-slot="{ active, checked }">
                <div :class="[
                    active
                        ? 'ring-2 ring-white/60 ring-offset-2 ring-offset-sky-300'
                        : '',
                    checked ? 'bg-sky-700/75 text-white ' : 'bg-white ',
                ]" class="flex cursor-pointer px-5 py-4 rounded shadow focus:outline-none">
                    <div class="flex w-full items-center justify-between">
                        <div class="flex items-center">
                            <div class="text-sm">
                                <RadioGroupLabel as="p" :class="checked ? 'text-white' : 'text-gray-900'"
                                    class="font-medium">
                                    {{ cartype }}
                                </RadioGroupLabel>
                            </div>
                        </div>
                        <div v-show="checked" class="shrink-0 text-white">
                            <IconCheck />
                        </div>
                    </div>
                </div>
            </RadioGroupOption>
        </div>
    </RadioGroup>
    <div class="mt-4">
        <label for="price" class="block text-sm font-medium leading-6 text-gray-900 mb-4">Price</label>
        <div class="relative mt-2 rounded-md shadow-sm">
            <div class="pointer-events-none absolute inset-y-0 left-0 flex items-center pl-3">
                <span class="text-gray-500 sm:text-sm">$</span>
            </div>
            <input v-model="bidRequest.bidAmount" type="text" name="price" id="price"
                class="block w-full rounded-md border-0 py-4 pl-7 pr-12 text-gray-900 ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-offset-sky-300 sm:text-sm sm:leading-6"
                placeholder="0.00" aria-describedby="price-currency" />
            <div class="pointer-events-none absolute inset-y-0 right-0 flex items-center pr-3">
                <span class="text-gray-500 sm:text-sm" id="price-currency">USD</span>
            </div>
        </div>
    </div>
</template>


<script setup lang="ts">
import { type BidRequest, CarType } from '@/types/models';
import { RadioGroup, RadioGroupLabel, RadioGroupOption, } from '@headlessui/vue'
import { ref } from 'vue';
import { watchDebounced } from "@vueuse/core"

import IconCheck from './icons/IconCheck.vue';

const emit = defineEmits<{
    (e: 'onChanged', request: BidRequest): void
}>()

const bidRequest = ref<BidRequest>({} as BidRequest)


watchDebounced(
    bidRequest.value, 
    () => {
        if(bidRequest.value.bidAmount !== undefined && bidRequest.value.carType !== undefined)
        {
            emit('onChanged', bidRequest.value)
        }
    },
    {
        debounce: 200
    }
)

</script>
