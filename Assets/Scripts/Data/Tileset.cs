using System;
using System.IO;

public class Tileset
{
    public TilesetTile[] tiles = new TilesetTile[201];
    public ushort base_tile_id;
    public ushort[] unknown = new ushort[31];

    internal static Tileset Parse(string path)
    {
        using (BinaryReader b = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            var ts = new Tileset();
            for (int i = 0; i < 201; i++)
                ts.tiles[i] = TilesetTile(b);

            ts.base_tile_id = b.ReadUInt16().SwapBytes();

            for (int i = 0; i < ts.unknown.Length; i++)
                ts.unknown[i] = b.ReadUInt16().SwapBytes();

            return ts;
        }
    }

    private static TilesetTile TilesetTile(BinaryReader b)
    {
        var t = new TilesetTile
        {
            sound_id = b.ReadUInt16().SwapBytes(),
            time_per_move = b.ReadUInt16().SwapBytes(),
            solid_type = b.ReadUInt16().SwapBytes(),
            is_shore = b.ReadUInt16().SwapBytes(),
            is_need_boat = b.ReadUInt16().SwapBytes(),
            is_path = b.ReadUInt16().SwapBytes(),
            blocks_los = b.ReadUInt16().SwapBytes(),
            need_fly_float = b.ReadUInt16().SwapBytes(),
            special_type = b.ReadUInt16().SwapBytes(),
            unknown5 = b.ReadInt16().SwapBytes()
        };
        for (int i = 0; i < 9; i++)
        {
            t.battle_expansion[i] = b.ReadInt16().SwapBytes();
        }
        t.unknown6 = b.ReadInt16().SwapBytes();
        return t;
    }
}

public class TilesetTile
{
    public ushort sound_id;
    public ushort time_per_move;
    public ushort solid_type; // 0 = not solid, 1 = solid to 1-box chars, 2 = solid
    public ushort is_shore;
    public ushort is_need_boat; // 1 = is boat, 2 = need boat
    public ushort is_path;
    public ushort blocks_los;
    public ushort need_fly_float;
    public ushort special_type; // 1 = trees, 2 = desert, 3 = shrooms, 4 = swamp, 5 = snow
    public short unknown5;
    public short[] battle_expansion = new short[9];
    public short unknown6;
}