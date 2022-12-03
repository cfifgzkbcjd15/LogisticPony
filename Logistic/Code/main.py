import folium


points = [
    [55.0492266, 32.7234924],
    [55.0492347, 32.7234684],
    [55.0474646, 32.722719],
    [55.0503789, 32.7284303],
    [55.0460872, 32.7152449],
]

def parse(array):
    map = folium.Map(location=array[0], zoom_start=15)
    for i in range(1, len(array)):
        folium.Marker(location=array[i], popup="Pony", icon=folium.Icon(color='gray')).add_to(map)
    folium.PolyLine(points).add_to(map)
    map.save("map.txt")

    with open('map.txt', 'rb+') as file:
        lines = file.readlines()
        for i in range(27):
            lines[i] = None
        lines[28] = None
        for i in range(35, 41):
            lines[i] = None
        lines[41] = None
        lines[42] = None
        return lines






