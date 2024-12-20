#!/bin/bash

if [[ "$OSTYPE" == "darwin"* ]]; then
    # macOS
    find ./node_modules/primeng/fesm2022 -type f -name "*.mjs" -exec sed -i '' 's/, i0\\.ɵɵStandaloneFeature],/],/g' {} +
else
    # Linux
    find ./node_modules/primeng/fesm2022 -type f -name "*.mjs" -exec sed -i 's/, i0\\.ɵɵStandaloneFeature],/],/g' {} +
fi
