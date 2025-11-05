# frozen_string_literal: true

require "json"

language_files = Dir["ValheimArmory/localizations/*"]
keys_to_remove = %w[item_battleaxe_blackmetal item_battleaxe_blackmetal_description]

language_files.each do |lang_file|
  next if lang_file == "ValheimArmory/localizations/English.json"

  lang_json = JSON.parse(File.read("#{lang_file}"))
  puts "Removing keys from #{lang_file}"
  keys_to_remove.each do |rm_key|
    lang_json.delete(rm_key)
  end
  File.open("#{lang_file}", "w") { |f| f.write(JSON.pretty_generate(lang_json)) }
end
