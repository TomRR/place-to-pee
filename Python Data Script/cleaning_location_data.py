# pip install pandas openpyxl xlwt xlrd

import pandas as pd

toilet_locations = pd.read_excel('berliner-toiletten-standorte.xlsx')

print(toilet_locations.head)
print(toilet_locations.columns)

toilet_locations['Description'] = toilet_locations['Description'].replace(to_replace='Toilette', value='')
toilet_locations['LabelID'] = toilet_locations['LabelID'].map(
    {
        1: 'berliner Toilette',
        2: 'City Toilette',
        3: 'WC-Center',
        4: 'Cafe Achreck',
        5: 'weitere ÖTs (z.B. Sanitärcontainer)',
        6: 'Toilette nicht von Wall'

    })
toilet_locations['Price'] = toilet_locations['Price'].map(
    {
        0: 'Kostenlos',
        0.1: '10 Cent',
        0.2: '20 Cent',
        0.3: '30 Cent',
        0.4: '40 Cent',
        0.5: '50 Cent',
        0.6: '60 Cent',
        0.7: '70 Cent',
        0.8: '80 Cent',
        0.9: '90 Cent',
        1: '1 Euro',
    })
# toilet_locations['Longitude'] = toilet_locations['Longitude'].replace(to_replace = ',', value = '.', inplace=True)
# toilet_locations['Latitude'] = toilet_locations['Latitude'].str.replace(',', '.', inplace=True)
# toilet_locations = toilet_locations.replace(to_replace='ö', value='oe')
# toilet_locations = toilet_locations.replace(to_replace='ü', value='ue')
# toilet_locations = toilet_locations.replace(to_replace='ß', value='ss')

toilet_locations = toilet_locations.drop('LavatoryID', axis=1)
toilet_locations = toilet_locations.drop('Number', axis=1)
# print(toilet_locations.head)
# print(toilet_locations.columns)
print(toilet_locations['LabelID'].head(10))
print(toilet_locations['Price'].head(10))
print(toilet_locations['Longitude'].head(10))
toilet_locations.to_csv('T_Toilet_Locations_Berlin.csv', sep=' ', decimal='.')

toilet_locations_csv = pd.read_csv('T_Toilet_Locations_Berlin.csv')

