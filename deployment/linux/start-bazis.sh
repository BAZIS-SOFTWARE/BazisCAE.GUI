#!/usr/bin/env bash
set -euo pipefail
app_dir="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
export BazisMeshPath="${BazisMeshPath:-$app_dir/libgmsh.so}"
export LD_LIBRARY_PATH="$app_dir${LD_LIBRARY_PATH:+:$LD_LIBRARY_PATH}"
cd -- "$app_dir"
exec "$app_dir/BazisAvaloniaGUI" "$@"
