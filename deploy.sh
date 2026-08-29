#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MOD_NAME="TheLegendarySword"
MODS_DIR="$HOME/.local/share/Steam/steamapps/common/Wildfrost/Modded/Wildfrost_Data/StreamingAssets/Mods/$MOD_NAME"

cd "$SCRIPT_DIR"

echo "Building $MOD_NAME (Release)..."
dotnet build -c Release

DLL_SRC="$SCRIPT_DIR/bin/Release/net472/$MOD_NAME.dll"
if [[ ! -f "$DLL_SRC" ]]; then
    echo "error: expected build output not found at $DLL_SRC" >&2
    exit 1
fi

mkdir -p "$MODS_DIR"

echo "Copying $MOD_NAME.dll -> $MODS_DIR/"
cp "$DLL_SRC" "$MODS_DIR/"

for asset in icon.png card-foreground.png card-background.png; do
    if [[ -f "$SCRIPT_DIR/$asset" ]]; then
        echo "Copying $asset -> $MODS_DIR/"
        cp "$SCRIPT_DIR/$asset" "$MODS_DIR/"
    fi
done

echo "Done. Installed at $MODS_DIR"
